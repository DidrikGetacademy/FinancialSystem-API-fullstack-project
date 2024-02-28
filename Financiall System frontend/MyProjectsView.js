projectview();
function projectview() {
    const app = document.getElementById("app");
    app.innerHTML = /*HTML*/ `
    <div class="container">
    <img src="/images/back.png" class="GoBackimg" onclick="HomepageView()"><img>
    ${ProjectList()}

    </div>
      `;
  }
  

  function ProjectList(){
    return /*html*/ `
    <div class="Project">
        <div>
            <label class="NameLabel">Project Name
            <ul  id="NameId"></ul>
            </label>
        </div>
        <div>
            <label class="DescriptionLabel">Description
            <ul id="DescriptionId"></ul>
            </label>
        </div>
    </div>
    `;
    }
