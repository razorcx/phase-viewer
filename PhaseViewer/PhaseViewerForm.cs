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
		private readonly List<Part> _secondaryParts;

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

			var parts = GetParts();
			_mainParts = GetMainParts(parts);
			_secondaryParts = GetSecondaryParts(parts);
		}

		private void PhaseViewerForm_Load(object sender, EventArgs e)
		{
			var phases = _model.GetPhases()
				.OfType<Phase>()
				.ToList()
				.Select(p => new PhaseView
				{
					Number = p.PhaseNumber,
					Name = p.PhaseName,
					Comment = p.PhaseComment,
					Current = p.IsCurrentPhase == 1
				}).ToList();

			phases.Sort((a,b) => a.Number.CompareTo(b.Number));

			dataGridViewPhases.DataSource = phases;
		}

		private void buttonShowAllPhases_Click(object sender, EventArgs e)
		{
			var phaseGroups = _mainParts.GroupBy(p =>
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
			var phaseNumber = GetPhaseNumber();
			var modelObjects = GetModelObjects(phaseNumber);
			ModelObjectVisualization.SetTemporaryState(modelObjects, _phaseColors[phaseNumber]);
		}

		private void buttonHidePhase_Click(object sender, EventArgs e)
		{
			var phaseNumber = GetPhaseNumber();
			var modelObjects = GetModelObjects(phaseNumber);
			ModelObjectVisualization.SetTransparency(modelObjects, TemporaryTransparency.HIDDEN);
		}

		private void buttonResetViews_Click(object sender, EventArgs e)
		{
			ModelObjectVisualization.ClearAllTemporaryStates();
		}

		private int GetPhaseNumber()
		{
			var phaseView = dataGridViewPhases?.CurrentRow?.DataBoundItem as PhaseView;
			return phaseView?.Number ?? 0;
		}

		private List<ModelObject> GetModelObjects(int phaseNumber)
		{
			var mainParts = GetMainPartsByPhase(phaseNumber);
			var secondaryParts = GetSecondaryPartsByPhase(phaseNumber);

			var modelObjects = new List<ModelObject>();
			if (checkBoxMainParts.Checked)
				modelObjects.AddRange(mainParts);
			if (checkBoxSecondaryParts.Checked)
				modelObjects.AddRange(secondaryParts);

			ModelObjectEnumerator.AutoFetch = true;

			return modelObjects;
		}

		private List<Part> GetMainPartsByPhase(int phaseNumber)
		{
			return
				_mainParts
					.Where(p =>
					{
						p.GetPhase(out Phase phase);
						return phase.PhaseNumber == phaseNumber;
					})
					.ToList();
		}

		private List<Part> GetSecondaryPartsByPhase(int phaseNumber)
		{
			return
				_secondaryParts
					.Where(p =>
					{
						p.GetPhase(out Phase phase);
						return phase.PhaseNumber == phaseNumber;
					})
					.ToList();
		}

		private List<Part> GetMainParts(List<Part> parts = null)
		{
			if (parts == null || !parts.Any())
				parts = GetParts();

			var mainParts = parts.AsParallel().Where(p =>
			{
				int isMainPart = 0;
				p.GetReportProperty("MAIN_PART", ref isMainPart);
				return isMainPart > 0;
			}).ToList();

			return mainParts;
		}

		private List<Part> GetSecondaryParts(List<Part> parts = null)
		{
			if (parts == null || !parts.Any())
				parts = GetParts();

			var mainParts = parts.AsParallel().Where(p =>
			{
				int isMainPart = 0;
				p.GetReportProperty("MAIN_PART", ref isMainPart);
				return isMainPart < 1;
			}).ToList();

			return mainParts;
		}

		private List<Part> GetParts()
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

			return parts;
		}
	}

	public class PhaseView
	{
		public int Number { get; set; }
		public string Name { get; set; }
		public string Comment { get; set; }
		public bool Current { get; set; }
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
