<<<<<<< HEAD
define( function() {
=======
define( [
	"../../core"
], function( jQuery ) {
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f

/**
 * Determines whether an object can have data
 */
<<<<<<< HEAD
return function( owner ) {

	// Accepts only:
	//  - Node
	//    - Node.ELEMENT_NODE
	//    - Node.DOCUMENT_NODE
	//  - Object
	//    - Any
	/* jshint -W018 */
	return owner.nodeType === 1 || owner.nodeType === 9 || !( +owner.nodeType );
=======
return function( elem ) {
	var noData = jQuery.noData[ ( elem.nodeName + " " ).toLowerCase() ],
		nodeType = +elem.nodeType || 1;

	// Do not set data on non-element DOM nodes because it will not be cleared (#8335).
	return nodeType !== 1 && nodeType !== 9 ?
		false :

		// Nodes accept data unless otherwise specified; rejection can be conditional
		!noData || noData !== true && elem.getAttribute( "classid" ) === noData;
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
};

} );
