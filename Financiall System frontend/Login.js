function LoginView() {
    const app = document.getElementById("app");
    app.innerHTML = /*HTML*/ `
    <div class="container">
    <div>${LoginMenu()}</div>
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
<button  onclick="LoginUser()">Login</button>
`;
}




