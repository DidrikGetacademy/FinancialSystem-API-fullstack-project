function RegisterView() {
    const app = document.getElementById("app");
    app.innerHTML = /*HTML*/ `
    <div class="container">
    ${registerMenu()}
    </div>
      `;
  }
  
  function registerMenu() {
    return /*html*/ `
    <img src="/images/back.png" class="GoBackimg" onclick="view()"><img>
    <h1 >Create new account</h1>
    <label >Username:</label>
    <input  id="username"  required /><br/><br/>
  
    <label >Password:</label>
    <input type="password" id="password" required/><br/><br/>
    <button  onclick="registerUser()">Register</button>
  `;
  }




