
let serialNumbers = []

const collectionTitles = document.querySelectorAll(".collection-title");
const collectionSubMenus = document.querySelectorAll(
  ".sidebar-collection-submenu-links"
);

const productCategoryList = [
  {
    "id": 1,
    "value": "فضاهای خانگی ( آشپزخانه، اتاق خواب، نشیمن و...)"
  },
  {
    "id": 2,
    "value": "فضاهای عمومی ( نمایشگاه، باشگاه، سینما، هتل و...)"
  },
  {
    "id": 3,
    "value": "فضاهای اداری ( سالن انتظار، اتاق جلسات و ...)"
  },
  {
    "id": 4,
    "value": "فضاهای آموزشی ( دانشگاه، مدرسه، مهد کودک و ...)"
  },
  {
    "id": 5,
    "value": "سایر..."
  }
]

const CategoryDetail = {
  "all": {
    title: "محصولات",
    persian_title: "",
    desc: "محصولات زیلوت در چهار دسته‌ی مینیمال، اسپرت، کلاسیک و آفیس عرضه می‌شوند تا پاسخگوی سبک‌های متنوع زندگی و نیازهای مختلف باشند. این موکت‌ها با استفاده از مواد اولیه مرغوب و تکنولوژی روز تولید شده و دارای ویژگی‌هایی چون ضد الکتریسیته، ضد اشتعال و آنتی باکتریال و  همچنین قابلیت آنتی استاتیک شدن را دارند ؛ مزایایی که علاوه بر دوام و ایمنی بالا، محیطی سالم، شیک و متناسب با هر نوع دکوراسیون ایجاد می‌کنند."
  },
  "sport": {
    title: "SPORT",
    persian_title: "اســـپرت",
    desc: "محصولات اسپرت زیلوت با طراحی جوان‌پسند، پرانرژی و خلاقانه، بهترین انتخاب برای فضاهایی هستند که به دنبال تحرک، تنوع و سرزندگی‌اند. این مجموعه با استفاده از رنگ‌ها و طرح‌های متنوع، امکان ایجاد فضایی پویا و متفاوت را فراهم می‌کند و هم‌زمان از کیفیت و مقاومت بالایی برخوردار است.موکت‌های اسپرت زیلوت علاوه بر ظاهر جذاب و مدرن، با دوام بالا و ویژگی‌های کاربردی خود، برای محیط‌های پررفت‌وآمد و خلاقانه ایده‌آل هستند. اگر به دنبال محیطی الهام‌بخش و متفاوت هستید، انتخاب محصولات اسپرت زیلوت تجربه‌ای تازه و پرانرژی برایتان رقم خواهد زد."
  },
  "minimal": {
    title: "MINIMAL",
    persian_title: "میــنیـــــمال",
    desc: "محصولات مینیمال زیلوت با طراحی ساده، شیک و هماهنگ با سبک‌های مدرن، انتخابی هوشمندانه برای فضاهایی هستند که به دنبال زیبایی آرام و بدون اغراق‌اند. این مجموعه با استفاده از مواد اولیه مرغوب و تکنولوژی روز تولید شده و علاوه بر ظاهر چشم‌نواز، از دوام و کیفیت بالا برخوردار است. موکت‌های مینیمال زیلوت در رنگ‌ها و بافت‌های متنوع عرضه می‌شوند تا به‌راحتی با هر نوع دکوراسیون مدرن سازگار شوند و فضایی یکدست، آرام و دلنشین ایجاد کنند. اگر به دنبال ترکیبی از سادگی، ظرافت و کارایی هستید، محصولات مینیمال زیلوت بهترین انتخاب برای شما خواهند بود."
  },
  "classic": {
    title: "CLASSIC",
    persian_title: "کلاسیــــــــــک",
    desc: "محصولات کلاسیک زیلوت، نمادی از اصالت، وقار و ماندگاری هستند؛ انتخابی ایده‌آل برای فضاهایی با سبک سنتی، رسمی و مجلل. این مجموعه با بهره‌گیری از مواد اولیه مرغوب و فناوری روز تولید شده و علاوه بر زیبایی چشم‌نواز، از دوام و مقاومت بالا برخوردار است. طرح‌ها و بافت‌های کلاسیک زیلوت، با جزئیات دقیق و رنگ‌های اصیل، فضایی پرشکوه و متمایز می‌آفرینند و تجربه‌ای ترکیبی از شیک بودن و آرامش پایدار را به محیط هدیه می‌دهند."
  },
  "office": {
    title: "OFFICE",
    persian_title: "آفیــس",
    desc: "محصولات آفیس زیلوت با طراحی کاربردی، مقاوم و شیک، انتخابی ایده‌آل برای دفاتر و محیط‌های کاری حرفه‌ای هستند. این مجموعه با استفاده از مواد باکیفیت و فناوری روز تولید شده و علاوه بر ظاهر مدرن، دوام بالا و راحتی استفاده را تضمین می‌کند.موکت‌های آفیس زیلوت با طرح‌ها و رنگ‌های متنوع و کلاسیک، محیط کاری را به فضایی منظم، حرفه‌ای و دلنشین تبدیل می‌کنند و تجربه‌ای از کارایی، زیبایی و آسایش را همزمان برای کاربران فراهم می‌آورند."
  },
}


const about = [
  {
    title: "چشم‌ انداز زیلوت",
    desc: "چشم‌انداز ما تبدیل شدن به برند پیشرو و الهام‌بخش صنعت موکت ایران و حضوری قدرتمند در بازارهای بین‌المللی است. زیلوت می‌خواهد اولین انتخاب کسانی باشد که به دنبال موکتی شیک، بادوام و متفاوت هستند و نامی مترادف با اعتماد، نوآوری و پیشرفت در ذهن‌ها باقی بگذارد.",
  },
  {
    title: "مأموریت زیلوت",
    desc: "ماموریت ما خلق محصولاتی است که در عین زیبایی و نوآوری، بالاترین سطح کیفیت، دوام و ایمنی را برای مشتریان فراهم کنند. زیلوت متعهد است با طراحی هوشمندانه و توجه به جزئیات، انتخابی مطمئن، کاربردی و متمایز را به هر خانه و فضایی ارائه دهد.",
  },
  {
    title: "ارزش‌های برند زیلوت",
    desc: `
      <ol style="list-style: arabic-indic;" class="pr-8">
      <li>کیفیت ماندگار – تعهد به استفاده از بهترین مواد اولیه و فناوری روز برای ارائه محصولاتی بادوام.</li>
      <li>نوآوری مستمر – جسارت در طراحی و تولید برای خلق راه‌حل‌های خلاقانه و متفاوت.</li>
      <li>مشتری‌مداری – تمرکز بر رضایت مشتریان و ارائه تجربه‌ای فراتر از انتظار.</li>
      <li>زیبایی و طراحی مدرن – توجه به جزئیات برای ایجاد فضایی خاص و متفاوت در هر محیط.</li>
      <li> پایداری و مسئولیت‌پذیری – تعهد به حفظ محیط‌زیست و توسعه پایدار در تمام مراحل تولید.</li>
      </ol>`,
  },
]

const homeCategoryHandler = (category, e) => {
  document
    .querySelector(".currentCateory")
    .classList.remove("currentCategory");
  e.target.classList.add("currentCategory");
};

const scrollDown = () => {
  window.scrollTo({
    top: window.innerHeight * 0.8,
    behavior: "smooth",
  });
};

const scrollToTop = () => {
  window.scrollTo({
    top: 0,
    behavior: "smooth",
  });
};

const aboutHandler = (index, e) => {

  document.getElementById("aboutTitle").innerHTML = about[index].title;
  document.getElementById("aboutDesc").innerHTML = about[index].desc;

  document.querySelector(".currentAbout").classList.remove("currentAbout");
  e.target.classList.add("currentAbout");
};

const changeColorHandler = (e) => {
  document.querySelector(".currentColor").classList.remove("currentColor");
  e.target.classList.add("currentColor");
};

const productCategoryHandler = (category, e) => {
  document
    .querySelector(".currentProductCat")
    .classList.remove("currentProductCat");
  e.target.classList.add("currentProductCat");

  document.getElementById("productHeadTitle").textContent = CategoryDetail[category].title
  document.getElementById("productHeadSubtitle").textContent = CategoryDetail[category].persian_title
  document.getElementById("productHeadBody").textContent = CategoryDetail[category].desc


};

const closeMenu = () => {
  document.querySelector(".sidebarMenu").style.opacity = "0";
  document.body.classList.remove("no-scroll");
  setTimeout(() => {
    document
      .querySelector(".sidebarMenu-container")
      .classList.add("menuClosed");
  }, 100);
};

const openMenu = () => {
  document
    .querySelector(".sidebarMenu-container")
    .classList.remove("menuClosed");
  document.body.classList.add("no-scroll");
  setTimeout(() => {
    document.querySelector(".sidebarMenu").style.opacity = "1";
  }, 200);
};



const addTagInput = () => {
  const input = document.getElementById("serialNumbers")
  let val = input.value
  if (val && val.trim().length !== 0)
    serialNumbers.push(val)
  input.value = ""
  document.getElementById("hiddenInput").value = serialNumbers.join("/")
  renderTags()
}

const renderTags = () => {
  let tagsTemp = serialNumbers.map((item, index) => {
    return `<div
                                    class="py-1 px-3 ps-1 border-1 font-semibold text-green border-lightGreen bg-pastelGreen shadow-sm flex items-center gap-3">
                                    <div class="bg-white p-1 cursor-pointer" onclick="removeTag(${index})">
                                        <svg xmlns="http://www.w3.org/2000/svg" height="16px" viewBox="0 -960 960 960"
                                            width="16px" fill="var(--green)">
                                            <path
                                                d="m256-200-56-56 224-224-224-224 56-56 224 224 224-224 56 56-224 224 224 224-56 56-224-224-224 224Z" />
                                        </svg>
                                    </div>
                                    <p>${item}</p>

                                </div>`
  }).join("")

  document.getElementById("tagsContainer").innerHTML = tagsTemp
}

const removeTag = (index) => {
  serialNumbers.splice(index, 1)
  document.getElementById("hiddenInput").value = serialNumbers.join("/")
  renderTags()
}


const openSelectHandler = () => {
  document.getElementById("selectBoxOptions").classList.remove("hidden")
}

const selectOption = (option, e) => {
  document.querySelector(".selectedOption")?.classList.remove("selectedOption")
  document.getElementById("productCategory").value = productCategoryList.find(item => item.id == option).value
  document.getElementById("hiddenProductCategory").value = +option
  event.target.classList.add("selectedOption")

}





window.addEventListener("click", (e) => {
  if (e.target.getAttribute("id") !== 'selectBoxOptions' && e.target.parentElement.getAttribute("id") !== 'selectBoxOptions' && e.target.getAttribute("id") !== 'productCategory')
    document.getElementById("selectBoxOptions").classList.add("hidden")
})


const renderOptions = () => {
  let temp = productCategoryList.map((item) => {
    return ` <div class="w-full p-3 py-4 bg-white hover:bg-pastelGreen cursor-pointer duration-300 text-lg" onclick="selectOption('${item.id}')">
                                ${item.value}
                            </div>`
  }).join("")
  
  document.getElementById("selectBoxOptions").innerHTML = temp
}

renderOptions()
