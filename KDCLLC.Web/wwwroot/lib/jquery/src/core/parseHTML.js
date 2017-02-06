define( [
	"../core",
	"../var/document",
	"./var/rsingleTag",
<<<<<<< HEAD
	"../manipulation/buildFragment",

	// This is the only module that needs core/support
	"./support"
], function( jQuery, document, rsingleTag, buildFragment, support ) {

// Argument "data" should be string of html
=======
	"../manipulation/buildFragment"
], function( jQuery, document, rsingleTag, buildFragment ) {

// data: string of html
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
// context (optional): If specified, the fragment will be created in this context,
// defaults to document
// keepScripts (optional): If true, will include scripts passed in the html string
jQuery.parseHTML = function( data, context, keepScripts ) {
	if ( !data || typeof data !== "string" ) {
		return null;
	}
	if ( typeof context === "boolean" ) {
		keepScripts = context;
		context = false;
	}
<<<<<<< HEAD

	// Stop scripts or inline event handlers from being executed immediately
	// by using document.implementation
	context = context || ( support.createHTMLDocument ?
		document.implementation.createHTMLDocument( "" ) :
		document );
=======
	context = context || document;
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f

	var parsed = rsingleTag.exec( data ),
		scripts = !keepScripts && [];

	// Single tag
	if ( parsed ) {
		return [ context.createElement( parsed[ 1 ] ) ];
	}

	parsed = buildFragment( [ data ], context, scripts );

	if ( scripts && scripts.length ) {
		jQuery( scripts ).remove();
	}

	return jQuery.merge( [], parsed.childNodes );
};

return jQuery.parseHTML;

} );
