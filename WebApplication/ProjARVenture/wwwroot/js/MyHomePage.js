
    // Cart functionality
    let cart = [];

    function addToCart(item) {
        cart.push(item);
    updateCartCount();
    alert(item + " added to cart!");
    }

    function updateCartCount() {
        document.querySelector('.cart-count').innerText = cart.length;
    }

    function viewCart() {
        alert("Items in cart: " + cart.join(', '));
    }

    // AR functions
    function launchARFashion(imageUrl) {
        alert("Launching AR for fashion item: " + imageUrl);
    window.location.href = '/LaunchARFashion?image=' + encodeURIComponent(imageUrl);
    }

    function launchARDesign(imageUrl) {
        alert("Launching AR for furniture item: " + imageUrl);
        window.location.href = '/LaunchARFashion?image=' + encodeURIComponent(imageUrl);
    }
