
function ForumView() {
    const app = document.getElementById("app");
    app.innerHTML = /*HTML*/ `
    <div class="container">
    <img src="/images/back.png" class="GoBackimg" onclick="HomepageView()"><img>
    ${forumDetails()}
    </div>
      `;
  }
  


function forumDetails(){
return /*html*/`
<div></div>

`
}