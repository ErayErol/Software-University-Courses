function solve() {
  let siteElements = document.getElementsByClassName("link-1");

  for (let siteElement of siteElements) {
    siteElement.addEventListener("click", function(e) {
      let currentTarget = e.currentTarget;

      let paragraphElement = currentTarget.getElementsByTagName("p")[0];
      let text = paragraphElement.textContent;
      let textParts = text.split(" ");
      let clicks = Number(textParts[1]);
      clicks++;

      textParts[1] = clicks;
      paragraphElement.textContent = textParts.join(" ");
    });
  }
}