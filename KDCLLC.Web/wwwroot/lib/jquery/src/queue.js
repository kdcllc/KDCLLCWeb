define( [
	"./core",
<<<<<<< HEAD
	"./data/var/dataPriv",
	"./deferred",
	"./callbacks"
], function( jQuery, dataPriv ) {
=======
	"./deferred",
	"./callbacks"
], function( jQuery ) {
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f

jQuery.extend( {
	queue: function( elem, type, data ) {
		var queue;

		if ( elem ) {
			type = ( type || "fx" ) + "queue";
<<<<<<< HEAD
			queue = dataPriv.get( elem, type );
=======
			queue = jQuery._data( elem, type );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f

			// Speed up dequeue by getting out quickly if this is just a lookup
			if ( data ) {
				if ( !queue || jQuery.isArray( data ) ) {
<<<<<<< HEAD
					queue = dataPriv.access( elem, type, jQuery.makeArray( data ) );
=======
					queue = jQuery._data( elem, type, jQuery.makeArray( data ) );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
				} else {
					queue.push( data );
				}
			}
			return queue || [];
		}
	},

	dequeue: function( elem, type ) {
		type = type || "fx";

		var queue = jQuery.queue( elem, type ),
			startLength = queue.length,
			fn = queue.shift(),
			hooks = jQuery._queueHooks( elem, type ),
			next = function() {
				jQuery.dequeue( elem, type );
			};

		// If the fx queue is dequeued, always remove the progress sentinel
		if ( fn === "inprogress" ) {
			fn = queue.shift();
			startLength--;
		}

		if ( fn ) {

			// Add a progress sentinel to prevent the fx queue from being
			// automatically dequeued
			if ( type === "fx" ) {
				queue.unshift( "inprogress" );
			}

<<<<<<< HEAD
			// Clear up the last queue stop function
=======
			// clear up the last queue stop function
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
			delete hooks.stop;
			fn.call( elem, next, hooks );
		}

		if ( !startLength && hooks ) {
			hooks.empty.fire();
		}
	},

<<<<<<< HEAD
	// Not public - generate a queueHooks object, or return the current one
	_queueHooks: function( elem, type ) {
		var key = type + "queueHooks";
		return dataPriv.get( elem, key ) || dataPriv.access( elem, key, {
			empty: jQuery.Callbacks( "once memory" ).add( function() {
				dataPriv.remove( elem, [ type + "queue", key ] );
=======
	// not intended for public consumption - generates a queueHooks object,
	// or returns the current one
	_queueHooks: function( elem, type ) {
		var key = type + "queueHooks";
		return jQuery._data( elem, key ) || jQuery._data( elem, key, {
			empty: jQuery.Callbacks( "once memory" ).add( function() {
				jQuery._removeData( elem, type + "queue" );
				jQuery._removeData( elem, key );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
			} )
		} );
	}
} );

jQuery.fn.extend( {
	queue: function( type, data ) {
		var setter = 2;

		if ( typeof type !== "string" ) {
			data = type;
			type = "fx";
			setter--;
		}

		if ( arguments.length < setter ) {
			return jQuery.queue( this[ 0 ], type );
		}

		return data === undefined ?
			this :
			this.each( function() {
				var queue = jQuery.queue( this, type, data );

<<<<<<< HEAD
				// Ensure a hooks for this queue
=======
				// ensure a hooks for this queue
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
				jQuery._queueHooks( this, type );

				if ( type === "fx" && queue[ 0 ] !== "inprogress" ) {
					jQuery.dequeue( this, type );
				}
			} );
	},
	dequeue: function( type ) {
		return this.each( function() {
			jQuery.dequeue( this, type );
		} );
	},
	clearQueue: function( type ) {
		return this.queue( type || "fx", [] );
	},

	// Get a promise resolved when queues of a certain type
	// are emptied (fx is the type by default)
	promise: function( type, obj ) {
		var tmp,
			count = 1,
			defer = jQuery.Deferred(),
			elements = this,
			i = this.length,
			resolve = function() {
				if ( !( --count ) ) {
					defer.resolveWith( elements, [ elements ] );
				}
			};

		if ( typeof type !== "string" ) {
			obj = type;
			type = undefined;
		}
		type = type || "fx";

		while ( i-- ) {
<<<<<<< HEAD
			tmp = dataPriv.get( elements[ i ], type + "queueHooks" );
=======
			tmp = jQuery._data( elements[ i ], type + "queueHooks" );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
			if ( tmp && tmp.empty ) {
				count++;
				tmp.empty.add( resolve );
			}
		}
		resolve();
		return defer.promise( obj );
	}
} );

return jQuery;
} );
