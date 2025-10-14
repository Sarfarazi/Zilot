

const searchBoxToggle = () => {
  document.querySelector(".searchBox").classList.toggle("hidden")
}

const searchBar = document.querySelector(".searchBtn")
searchBar.addEventListener("click", searchBoxToggle)




// let Products = []

// async function searchHandler() {
// try {
//   const res = await fetch("http://localhost:5067/api/zelut/product/get-products/0");
//   if (!res.ok) {
//     throw new Error(`HTTP error! status: ${res.status}`);
//   }
//   const data = await res.json();
//   Products = data.data
// } catch (error) {
//   console.error("Fetch error:", error);
// }

// }

// searchHandler()

