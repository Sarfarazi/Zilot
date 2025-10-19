
const searchInput = document.getElementById("search")

const searchBoxToggle = () => {
  searchInput.value = ""
  document.querySelector(".searchBox").classList.toggle("hidden")
}

const searchBar = document.querySelector(".searchBtn")
searchBar.addEventListener("click", searchBoxToggle)


searchInput.addEventListener("keyup", () => {
  if (event.target.value.trim() !== "") {
    searchHandler(event.target.value)
  }
})


const searchHandler = (value) => {
  fetch(`http://localhost:5067/search-products/${value.trim()}`)
    .then(res => res.json())
    .then(data => renderSearchResult(data))
}

const renderSearchResult = (res) => {
  let temp;
  if (res && res.data.length > 0) {
    temp = res.data.map(item => {
      let newTemp;
      if (item.zelutDetail && item.zelutDetail.length > 0) {
        newTemp = item.zelutDetail.map(detail => {
          return `<a href="/Product/${item.id}/${detail.id}" class="p-3 w-full bg-gray-50 hover:bg-pastelGreen rounded-md mt-2 cursor-pointer">${item.nameModel}-${detail.nameJadid}</a>`
        }).join("")
      }
      return newTemp
    }).join("")
    document.getElementById("searchResult").innerHTML = temp
  } else {
    document.getElementById("searchResult").innerHTML = '<p class="p-3 bg-gray-50 hover:bg-pastelGreen rounded-md mt-2 cursor-pointer">محصولی یافت نشد</p>'

  }
}