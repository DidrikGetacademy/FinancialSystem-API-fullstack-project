function RegisterView() {
    const app = document.getElementById("app");
    app.innerHTML = /*HTML*/ `
    <div class="container">
    <div>${registerMenu()}</div>
    </div>
      `;
  }
  
  function registerMenu() {
    return /*html*/ `
    <h1 >Create new account</h1>
    <label >Username:</label>
    <input  id="username"  required /><br/><br/>
  
    <label >Password:</label>
    <input type="password" id="password" required/><br/><br/>
    <button  onclick="registerUser()">Register</button>
  `;
  }




