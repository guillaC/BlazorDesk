window.windowInterop = (function () {
    function getEl(id) {
        return document.getElementById(id);
    }

    function setStyle(id, styles) {
        const el = getEl(id);
        if (el) Object.assign(el.style, styles);
    }

    return {
        makeDraggableResizable: function (elementId, dotNetRef) {
            const el = getEl(elementId);
            if (!el) return;

            if (typeof $ === "undefined") {
                console.error("jQuery UI is required for draggable/resizable");
                return;
            }

            $(el).draggable({
                handle: ".window-header",
                stop: function (event, ui) {
                    const top = Math.round(ui.position.top);
                    const left = Math.round(ui.position.left);
                    const width = Math.round(ui.helper.outerWidth());
                    if (dotNetRef) {
                        dotNetRef.invokeMethodAsync("UpdatePosition", top, left, width);
                    }
                }
            }).resizable();
        },

        setZIndex: (id, z) => setStyle(id, { zIndex: z }),
        setWidth: (id, w) => setStyle(id, { width: w + "px" }),
        setPosition: (id, top, left) => setStyle(id, { top: top + "px", left: left + "px" })
    };
})();
