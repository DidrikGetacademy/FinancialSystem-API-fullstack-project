function HomepageView(username) {
    const app = document.getElementById("app");
    app.innerHTML = /*HTML*/ `
    <div class="container">
    <div>${Homepage(username)}</div>
    </div>
      `;
  }
  

  function Homepage(username){
return /*HTML*/`
<div>User: ${username}</div>
`;
} 