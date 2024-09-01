
//document.addEventListener("DOMContentLoaded", function () {

//    document.getElementById("Loginbtn").onclick = function () {
//        console.log("login clicked")
//    }





//});

//function LoginUser() {
//    let username = document.getElementById("username").value;
//    let password = document.getElementById("password").value;
//    let apiurl = 'https://localhost:7213/AuthenticteUser';

//    const jsonData = {
//        username: username,
//        password: password
//    };

//    fetch(apiurl, {
//        method: 'POST',
//        credentials: 'include',
//        headers: {
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify(jsonData)
//    })
//        .then(response => {
//            if (!response.ok) {
//                return response.text().then(text => {
//                    throw new Error(`Request failed with status ${response.status}: ${text}`);
//                });
//            }
//            return response.json();
//        })
//        .then(data => {
//            console.log('Success:', data);
//            // Handle the data received from the API
//        })
//        .catch(error => {
//            console.error('There was a problem with the fetch operation:', error);
//        });

//    console.log("login clicked");
//}

function LoginUser() {
    let username = document.getElementById("username").value;
    let password = document.getElementById("password").value;
    let apiurl = 'https://localhost:7213/AuthenticteUser';

    const jsonData = {
        username: username,
        password: password
    };

    $.ajax({
        url: apiurl,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(jsonData),
        success: function (data) {
            console.log('Success:', data);
            if (data.status == true) {
                window.location.href = '/MyHomePage'
            }
            // Handle the data received from the API
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error('There was a problem with the ajax operation:', textStatus, errorThrown);
        }
    });

    console.log("login clicked");
}


function SignupUser() {
    let username = document.getElementById("sign_username").value;
    let password = document.getElementById("sign_password").value;
    let email = document.getElementById("sign_email").value;
    let apiurl = 'https://localhost:7213/RegisterUser';

    const jsonData = {
        username: username,
        password: password,
        email: email
    };

    $.ajax({
        url: apiurl,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(jsonData),
        success: function (data) {
            console.log('Success:', data);
            if (data.status == true) {
                showpopup();
                setTimeout( ()=> {
                    window.location.href = '/Login'
                },1000)
                
            }
            // Handle the data received from the API
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error('There was a problem with the ajax operation:', textStatus, errorThrown);
        }
    });

    console.log("login clicked");
}

function showpopup() {
    document.getElementById("successPopup").style.display = "block";
    setTimeout(closePopup,5000)
}

function closePopup(){
    document.getElementById("successPopup").style.display = "none";
}


