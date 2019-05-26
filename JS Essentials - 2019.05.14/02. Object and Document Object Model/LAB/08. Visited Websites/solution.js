function solve() {
  let siteElements = document.getElementsByClassName("link-1");

  for (let siteElement of siteElements) {
    siteElement.addEventListener("click", (e) => {
      let currentTarget = e.currentTarget;

      let paraElement = currentTarget.getElementsByTagName("p")[0];
      let text = paraElement.textContent;
      let textParts = text.split(" ");
      let clicks = Number(textParts[1]);
      clicks++;

      textParts[1] = clicks;
      paraElement.textContent = textParts.join(" ");
    });
  }


}