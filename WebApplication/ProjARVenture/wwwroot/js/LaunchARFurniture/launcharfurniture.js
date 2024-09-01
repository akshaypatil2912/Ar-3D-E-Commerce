document.addEventListener("DOMContentLoaded", function () {
    // Hide the loading screen once the AR is ready
    document.querySelector("a-scene").addEventListener("loaded", function () {
        document.getElementById("loading").style.display = "none";
    });

    // Select the entity containing the 3D model
    const sofa = document.getElementById('sofa');
    let rotation = { x: 0, y: 0, z: 0 };
    let isZoomedIn = false;

    // Function to rotate the model on click
    sofa.addEventListener('mousedown', function () {
        // Rotate the model 30 degrees on the Y axis
        rotation.y += 30;
        sofa.setAttribute('rotation', `${rotation.x} ${rotation.y} ${rotation.z}`);
    });

    // Function to zoom in and out on double click
    sofa.addEventListener('dblclick', function () {
        if (!isZoomedIn) {
            // Zoom in
            sofa.setAttribute('scale', '0.8 0.8 0.8');
        } else {
            // Zoom out
            sofa.setAttribute('scale', '1.0 0.5 3.5');
        }
        isZoomedIn = !isZoomedIn;
    });
});
