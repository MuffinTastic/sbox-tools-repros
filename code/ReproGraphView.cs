using Tools;

namespace Repro;

public class ReproGraphView : GraphicsView
{
	public ReproGraphView( Widget parent ) : base( parent )
	{
		Antialiasing = true;
		TextAntialiasing = true;
		BilinearFiltering = true;

		SceneRect = new Rect( -100000, -100000, 200000, 200000 );

		HorizontalScrollbar = ScrollbarMode.Off;
		VerticalScrollbar = ScrollbarMode.Off;
		MouseTracking = true;
	}

	Vector2 lastMousePosition;

	ReproConnection Preview;

	protected override void OnMousePress( MouseEvent e )
	{
		base.OnMousePress( e );

		var position = ToScene( e.LocalPosition );

		if ( Preview is null && e.LeftMouseButton )
		{
			Preview = new ReproConnection( position );
			Add( Preview );
		}
	}

	protected override void OnMouseReleased( MouseEvent e )
	{
		base.OnMouseReleased( e );

		if ( Preview is not null )
		{
			Preview.Destroy();
			Preview = null;
		}
	}

	protected override void OnMouseMove( MouseEvent e )
	{
		e.Accepted = true;
		lastMousePosition = ToScene( e.LocalPosition );

		if ( Preview is not null )
		{
			Preview.Layout( lastMousePosition );
		}
	}
}
