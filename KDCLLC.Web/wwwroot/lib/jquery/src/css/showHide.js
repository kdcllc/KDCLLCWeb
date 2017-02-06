<<<<<<< HEAD
define( [
	"../data/var/dataPriv"
], function( dataPriv ) {

=======
define( [], function() {
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
function showHide( elements, show ) {
	var display, elem,
		values = [],
		index = 0,
		length = elements.length;

	// Determine new display value for elements that need to change
	for ( ; index < length; index++ ) {
		elem = elements[ index ];
		if ( !elem.style ) {
			continue;
		}

		display = elem.style.display;
		if ( show ) {
			if ( display === "none" ) {

				// Restore a pre-hide() value if we have one
<<<<<<< HEAD
				values[ index ] = dataPriv.get( elem, "display" ) || "";
=======
				values[ index ] = jQuery._data( elem, "display" ) || "";
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
			}
		} else {
			if ( display !== "none" ) {
				values[ index ] = "none";

				// Remember the value we're replacing
<<<<<<< HEAD
				dataPriv.set( elem, "display", display );
=======
				jQuery._data( elem, "display", display );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
			}
		}
	}

	// Set the display of the elements in a second loop
	// to avoid the constant reflow
	for ( index = 0; index < length; index++ ) {
		if ( values[ index ] != null ) {
			elements[ index ].style.display = values[ index ];
		}
	}

	return elements;
}

return showHide;

} );
