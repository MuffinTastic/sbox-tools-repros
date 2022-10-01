using Tools;

namespace Repro;

[Tool( "Graphics Line Repro", "bug_report", "Double alloc" )]
public class ReproWindow : Window
{
	public ReproWindow()
	{
		Title = "Graphics Line Repro";
		Size = new Vector2( 640, 480 );

		CreateUI();
		Show();
	}

	public void CreateUI()
	{
		Canvas = new ReproGraphView( this );

		// dumb but who cares :)
		var l = new Label( "Click and drag anywhere", Canvas );
	}
}
