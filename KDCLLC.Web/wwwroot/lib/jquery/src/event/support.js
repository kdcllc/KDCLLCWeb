define( [
<<<<<<< HEAD
	"../var/support"
], function( support ) {

support.focusin = "onfocusin" in window;
=======
	"../var/document",
	"../var/support"
], function( document, support ) {

( function() {
	var i, eventName,
		div = document.createElement( "div" );

	// Support: IE<9 (lack submit/change bubble), Firefox (lack focus(in | out) events)
	for ( i in { submit: true, change: true, focusin: true } ) {
		eventName = "on" + i;

		if ( !( support[ i ] = eventName in window ) ) {

			// Beware of CSP restrictions (https://developer.mozilla.org/en/Security/CSP)
			div.setAttribute( eventName, "t" );
			support[ i ] = div.attributes[ eventName ].expando === false;
		}
	}

	// Null elements to avoid leaks in IE.
	div = null;
} )();
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f

return support;

} );
