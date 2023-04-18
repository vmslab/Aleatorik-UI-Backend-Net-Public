namespace AleatorikUI.Services.Model
{
	public class GraphNode
	{
		public string? id; // 식별값 ISB ID
		public string? name;
		public string? externalKey;
		public string? label;
		public string? type;
		public string? color; // Node의 색상 ex) "blue", "rgb(251, 160, 38)", ...
		public string? borderColor;
		public string? shape; // Node의 형태 ex) "triangle", "round-rectange", ...
		public string? parent;
		public double? width;
		public double? height;
		public double? borderWidth = 1;
		public string? borderStyle = "solid";
		public double? overlayOpacity = 0;
		public double? overlayPadding = 0;
		public string? overlayColor = "#1E28B3";
		public string? overlayShape = "ellipse";
	}
}
