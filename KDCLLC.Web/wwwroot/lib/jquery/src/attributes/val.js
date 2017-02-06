define( [
	"../core",
	"./support",
	"../core/init"
], function( jQuery, support ) {

<<<<<<< HEAD
var rreturn = /\r/g;
=======
var rreturn = /\r/g,
	rspaces = /[\x20\t\r\n\f]+/g;
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f

jQuery.fn.extend( {
	val: function( value ) {
		var hooks, ret, isFunction,
			elem = this[ 0 ];

		if ( !arguments.length ) {
			if ( elem ) {
				hooks = jQuery.valHooks[ elem.type ] ||
					jQuery.valHooks[ elem.nodeName.toLowerCase() ];

<<<<<<< HEAD
				if ( hooks &&
=======
				if (
					hooks &&
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
					"get" in hooks &&
					( ret = hooks.get( elem, "value" ) ) !== undefined
				) {
					return ret;
				}

				ret = elem.value;

				return typeof ret === "string" ?

<<<<<<< HEAD
					// Handle most common string cases
					ret.replace( rreturn, "" ) :

					// Handle cases where value is null/undef or number
=======
					// handle most common string cases
					ret.replace( rreturn, "" ) :

					// handle cases where value is null/undef or number
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
					ret == null ? "" : ret;
			}

			return;
		}

		isFunction = jQuery.isFunction( value );

		return this.each( function( i ) {
			var val;

			if ( this.nodeType !== 1 ) {
				return;
			}

			if ( isFunction ) {
				val = value.call( this, i, jQuery( this ).val() );
			} else {
				val = value;
			}

			// Treat null/undefined as ""; convert numbers to string
			if ( val == null ) {
				val = "";
<<<<<<< HEAD

			} else if ( typeof val === "number" ) {
				val += "";

=======
			} else if ( typeof val === "number" ) {
				val += "";
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
			} else if ( jQuery.isArray( val ) ) {
				val = jQuery.map( val, function( value ) {
					return value == null ? "" : value + "";
				} );
			}

			hooks = jQuery.valHooks[ this.type ] || jQuery.valHooks[ this.nodeName.toLowerCase() ];

			// If set returns undefined, fall back to normal setting
			if ( !hooks || !( "set" in hooks ) || hooks.set( this, val, "value" ) === undefined ) {
				this.value = val;
			}
		} );
	}
} );

jQuery.extend( {
	valHooks: {
		option: {
			get: function( elem ) {
<<<<<<< HEAD

				// Support: IE<11
				// option.value not trimmed (#14858)
				return jQuery.trim( elem.value );
=======
				var val = jQuery.find.attr( elem, "value" );
				return val != null ?
					val :

					// Support: IE10-11+
					// option.text throws exceptions (#14686, #14858)
					// Strip and collapse whitespace
					// https://html.spec.whatwg.org/#strip-and-collapse-whitespace
					jQuery.trim( jQuery.text( elem ) ).replace( rspaces, " " );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
			}
		},
		select: {
			get: function( elem ) {
				var value, option,
					options = elem.options,
					index = elem.selectedIndex,
					one = elem.type === "select-one" || index < 0,
					values = one ? null : [],
					max = one ? index + 1 : options.length,
					i = index < 0 ?
						max :
						one ? index : 0;

				// Loop through all the selected options
				for ( ; i < max; i++ ) {
					option = options[ i ];

<<<<<<< HEAD
					// IE8-9 doesn't update selected after form reset (#2551)
=======
					// oldIE doesn't update selected after form reset (#2551)
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
					if ( ( option.selected || i === index ) &&

							// Don't return options that are disabled or in a disabled optgroup
							( support.optDisabled ?
<<<<<<< HEAD
								!option.disabled : option.getAttribute( "disabled" ) === null ) &&
=======
								!option.disabled :
								option.getAttribute( "disabled" ) === null ) &&
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
							( !option.parentNode.disabled ||
								!jQuery.nodeName( option.parentNode, "optgroup" ) ) ) {

						// Get the specific value for the option
						value = jQuery( option ).val();

						// We don't need an array for one selects
						if ( one ) {
							return value;
						}

						// Multi-Selects return an array
						values.push( value );
					}
				}

				return values;
			},

			set: function( elem, value ) {
				var optionSet, option,
					options = elem.options,
					values = jQuery.makeArray( value ),
					i = options.length;

				while ( i-- ) {
					option = options[ i ];
<<<<<<< HEAD
					if ( option.selected =
							jQuery.inArray( jQuery.valHooks.option.get( option ), values ) > -1
					) {
						optionSet = true;
=======

					if ( jQuery.inArray( jQuery.valHooks.option.get( option ), values ) > -1 ) {

						// Support: IE6
						// When new option element is added to select box we need to
						// force reflow of newly added node in order to workaround delay
						// of initialization properties
						try {
							option.selected = optionSet = true;

						} catch ( _ ) {

							// Will be executed only in IE6
							option.scrollHeight;
						}

					} else {
						option.selected = false;
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
					}
				}

				// Force browsers to behave consistently when non-matching value is set
				if ( !optionSet ) {
					elem.selectedIndex = -1;
				}
<<<<<<< HEAD
				return values;
=======

				return options;
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
			}
		}
	}
} );

// Radios and checkboxes getter/setter
jQuery.each( [ "radio", "checkbox" ], function() {
	jQuery.valHooks[ this ] = {
		set: function( elem, value ) {
			if ( jQuery.isArray( value ) ) {
				return ( elem.checked = jQuery.inArray( jQuery( elem ).val(), value ) > -1 );
			}
		}
	};
	if ( !support.checkOn ) {
		jQuery.valHooks[ this ].get = function( elem ) {
			return elem.getAttribute( "value" ) === null ? "on" : elem.value;
		};
	}
} );

} );
