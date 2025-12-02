window.trackMouseMove = function (dotnetRef) {
    window.addEventListener('mousemove', e => {
        dotnetRef.invokeMethodAsync('HandleMouseMove', e.clientX, e.clientY);
    });
};