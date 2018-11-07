/*

Documentation styles for Purpose - Website UI Kit
IMPORTANT: No need to include docs.css in your project. These styles are for documentation only.

Product Page: https://themes.getbootstrap.com/product/purpose-website-ui-kit/
Author: Webpixels
Author URI: https://www.webpixels.io

---

Copyright 2018 Webpixels

*/

"use strict";

$(document).ready(function() {

	// Insert copy to clipboard button before .highlight
    $('figure.highlight, div.highlight').each(function() {
        var btnHtml = '<div class="code-clipboard"><button class="btn-clipboard" title="Copy to clipboard">Copy</button></div>'
        $(this).before(btnHtml)
        $('.btn-clipboard')
            .tooltip()
            .on('mouseleave', function() {
                // Explicitly hide tooltip, since after clicking it remains
                // focused (as it's a button), so tooltip would otherwise
                // remain visible until focus is moved away
                $(this).tooltip('hide')
            })
    })

    // Component code copy/paste
    var clipboard = new ClipboardJS('.btn-clipboard', {
        target: function(trigger) {
            return trigger.parentNode.nextElementSibling
        }
    })

    clipboard.on('success', function(e) {
        $(e.trigger)
            .attr('title', 'Copied!')
            .tooltip('_fixTitle')
            .tooltip('show')
            .attr('title', 'Copy to clipboard')
            .tooltip('_fixTitle')

        e.clearSelection()
    })

    clipboard.on('error', function(e) {
        var modifierKey = /Mac/i.test(navigator.userAgent) ? '\u2318' : 'Ctrl-'
        var fallbackMsg = 'Press ' + modifierKey + 'C to copy'

        $(e.trigger)
            .attr('title', fallbackMsg)
            .tooltip('_fixTitle')
            .tooltip('show')
            .attr('title', 'Copy to clipboard')
            .tooltip('_fixTitle')
    })
});
