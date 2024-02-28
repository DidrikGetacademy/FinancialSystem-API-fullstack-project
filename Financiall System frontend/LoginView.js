function LoginView() {
    const app = document.getElementById("app");
    app.innerHTML = /*HTML*/ `
    <div class="container">
    <img src="/images/back.png" class="GoBackimg" onclick="view()"><img>
    ${LoginMenu()}
    </div>
      `;
  }


  function LoginMenu() {
return /*html*/ `

<h1>Login</h1>
<label >Username:</label>
<input  id="username"  required /><br/><br/>

<label >Password:</label>
<input type="password" id="password" required/><br/><br/>
<button style="cursor: pointer;" onclick="LoginUser()">Login</button>
`;
}






