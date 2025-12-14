window.trackMouseMove = function (dotnetRef) {
    window.addEventListener('mousemove', e => {
        dotnetRef.invokeMethodAsync('HandleMouseMoveAsync', e.clientX, e.clientY);
    });
};