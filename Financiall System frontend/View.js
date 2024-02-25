view();
function view(){
    const app = document.getElementById("app");
    app.innerHTML = /*HTML*/ `
    <div class="container">
    <div>${HeadTitle()}<div>
    <div>${FrontPageButtons()}<div>
    </div>
    `;
}

function FrontPageButtons(){
    return /*HTML*/ `
    <button onclick="RegisterView()">Register</button>
    <button onclick="LoginView()">Login</button>
    `;
    }


function HeadTitle(){
return /*HTML*/`
<h1>Financial System</h1>
<h2>Welcome</h2>
<h2>sign in or register</h2>
`;
}