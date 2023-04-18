namespace AleatorikUI.Services.Model
{
	public class GraphEdge
	{
		public string? id; // 식별값 BOM ID
		public string? name;
		public string? externalKey;
		public string? label;
		public string? color; // Edge의 색상 ex) "blue", "rgb(251, 160, 38)", ...
		public string? source; // 시작 Node ID
		public string? target; // 끝 Node ID
		public double overlayOpacity = 0;
		public double overlayPadding = 0;
		public string overlayColor = "#1E28B3";
		public string overlayShape = "ellipse";
	}
}
