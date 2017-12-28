using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace PhaseViewer
{
	public partial class PhaseViewerForm : Form
	{
		private readonly Model _model = new Model();
		private readonly Dictionary<int, Color> _phaseColors;
		private readonly List<Part> _mainParts;

		public PhaseViewerForm()
		{
			InitializeComponent();

			_phaseColors = new Dictionary<int, Color>
			{
				{1, new Color(1, 0, 0)},
				{2, new Color(0, 1, 0)},
				{3, new Color(0, 0, 1)},
				{4, new Color(1, 1, 0)},
				{5, new Color(1, 1, 1)},
				{6, new Color(0, 1, 0)},
				{7, new Color(0, 0, 1)},
				{13, new Color(1, 0, 1)},
				{99, new Color(0, 1, 1)},
				{100, new Color(0, 1, .5)},
				{101, new Color(.5, .5, .5)},
				{9999, new Color(.5, 0, 0)},
				{10000, new Color(0, .5, 0)},
			};

			_mainParts = GetMainParts();
		}

		private void PhaseViewerForm_Load(object sender, EventArgs e)
		{
			var phases = _model.GetPhases()
				.OfType<Phase>()
				.ToList()
				.Select(p => new
				{
					Number = p.PhaseNumber,
					Name = p.PhaseName,
					Comment = p.PhaseComment,
					Current = p.IsCurrentPhase == 1 ? "CURRENT" : string.Empty
				}).ToList();

			phases.Sort((a,b) => a.Number.CompareTo(b.Number));

			dataGridViewPhases.DataSource = phases;
		}

		private List<Part> GetMainParts()
		{
			ModelObjectEnumerator.AutoFetch = true;

			var beams = _model.GetModelObjectSelector()
				.GetAllObjectsWithType(ModelObject.ModelObjectEnum.BEAM)
				.ToAList<Beam>();

			var bentPlates = _model.GetModelObjectSelector()
				.GetAllObjectsWithType(ModelObject.ModelObjectEnum.BENT_PLATE)
				.ToAList<BentPlate>();

			var contourPlates = _model.GetModelObjectSelector()
				.GetAllObjectsWithType(ModelObject.ModelObjectEnum.CONTOURPLATE)
				.ToAList<ContourPlate>();

			var polybeams = _model.GetModelObjectSelector()
				.GetAllObjectsWithType(ModelObject.ModelObjectEnum.POLYBEAM)
				.ToAList<PolyBeam>();

			var parts = new List<Part>();

			parts.AddRange(beams);
			parts.AddRange(bentPlates);
			parts.AddRange(contourPlates);
			parts.AddRange(polybeams);

			var mainParts = parts.AsParallel().Where(p =>
			{
				int isMainPart = 0;
				p.GetReportProperty("MAIN_PART", ref isMainPart);
				return isMainPart > 0;
			}).ToList();

			return mainParts;
		}

		private void buttonShowAllPhases_Click(object sender, EventArgs e)
		{
			var phaseGroups = _mainParts.AsParallel().GroupBy(p =>
			{
				p.GetPhase(out Phase phase);
				return phase.PhaseNumber;
			}).ToList();

			phaseGroups.ForEach(p =>
			{
				ModelObjectVisualization.SetTemporaryState(p.OfType<ModelObject>().ToList(), _phaseColors[p.Key]);
			});
		}

		private void buttonShowPhase_Click(object sender, EventArgs e)
		{
			dynamic row = dataGridViewPhases?.CurrentRow?.DataBoundItem;
			var phaseNumber = (int)row.Number;

			var modelObjects = _mainParts.AsParallel()
				.Where(p =>
				{
					p.GetPhase(out Phase phase);
					return phase.PhaseNumber == phaseNumber;
				})
				.OfType<ModelObject>()
				.ToList();

			ModelObjectVisualization.SetTemporaryState(modelObjects, _phaseColors[phaseNumber]);
		}
	}

	public static class ExtensionMethods
	{
		public static List<T> ToAList<T>(this IEnumerator enumerator)
		{
			var list = new List<T>();
			while (enumerator.MoveNext())
			{
				var current = enumerator.Current;
				if (!(current is T)) continue;
				list.Add((T)current);
			}
			return list;
		}
	}
}
