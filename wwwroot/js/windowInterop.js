window.windowInterop = {
    makeDraggableResizable: function (elementId, dotNetRef) {
        const el = document.getElementById(elementId);
        if (!el) {
            return;
        }

        if (typeof window.$ === "undefined") {
            setTimeout(() => window.windowInterop.makeDraggableResizable(elementId, dotNetRef), 100);
            return;
        }

        $(el).draggable({
            handle: ".window-header",
            stop: function (event, ui) {
                const top = Math.round(ui.position.top);
                const left = Math.round(ui.position.left);
                if (dotNetRef) {
                    dotNetRef.invokeMethodAsync("UpdatePosition", top, left);
                }
            }
        }).resizable();
    },

    setZIndex: function (elementId, zIndex) {
        const el = document.getElementById(elementId);
        if (el) {
            el.style.zIndex = zIndex;
        }
    },

    setPosition: function (elementId, top, left) {
        const el = document.getElementById(elementId);
        if (el) {
            el.style.top = top + "px";
            el.style.left = left + "px";
        }
    }
};
