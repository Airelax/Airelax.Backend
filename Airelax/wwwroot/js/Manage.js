let barBtn = document.querySelectorAll('.barBtn');
let detailSection = document.querySelector('.detail-section');
let priceSection = document.querySelector('.price-section');
let policySection = document.querySelector('.policy-rule-section');
let contentDiv = document.querySelectorAll('.content');
let instanceBooking = [
    {name: "instance", title: "即時預訂功能已開啟", detail: "符合所有條件的房客可以即時預訂房源，其他房客則須傳送預訂申請。若你對預訂有任何疑慮，可取消且免受處罰。"},
    {name: "instance", title: "即時預訂功能已關閉", detail: "所有房客都必須傳送預訂申請"}
];
let unBooking = [
    {name: "unBooking", title: "彈性", detail: "在入住日1天前取消預訂，可獲得全額退款"},
    {name: "unBooking", title: "彈性或不可退款", detail: "除了彈性退訂政策外，您還可以提供不可退款選項：房客雖然會少付10%的費用，不過無論何時對方取消預訂，您都能保留全數收款。"},
    {name: "unBooking", title: "中等", detail: "在入住日5天前取消預訂，可獲得全額退款"},
    {name: "unBooking", title: "中等或不可退款", detail: "除了中等退訂政策外，您還可以提供不可退款選項：房客雖然會少付10%的費用，不過無論何時對方取消預訂，您都能保留全數收款。"},
    {
        name: "unBooking",
        title: "稍嚴",
        detail: "最晚在入住前 30 天取消可拿回全額退款。如果在入住前 30 天預訂，並在預訂後 48 小時內且入住前至少 14 天取消，即可拿回全額退款。在此之後，最晚在入住前 7 天取消可拿回 50% 退款。在這之後取消則不予退款。"
    },
    {name: "unBooking", title: "較嚴格或不可退款", detail: "除了《較嚴格退訂政策》外，你也可以提供不可退款選項：房客雖然會少付 10% 費用，但若取消預訂，你就能保留全數收款。"},
    {
        name: "unBooking",
        title: "嚴格",
        detail: "針對14天之後的預訂，若房客在預訂後48小時內取消，可以獲得全額退款。提早入住日期7天前取消預訂，可獲得50%退款。旅程開始前7天內取消，則無法退款。"
    },
    {name: "unBooking", title: "嚴格或不可退款", detail: "除了嚴格退訂政策外，您還可以提供不可退款選項：房客雖然會少付10%的費用，不過萬一對方取消預訂，您就能保留全數收款。"},
];
let status = [
    {
        name: "unBooking",
        title: "已發布",
        detail: "房客可以在搜尋結果中找到你的房源，且可以提出預訂申請或預訂日曆上開放的日期。",
        icon: '<img src="/icon/Published.svg" alt="publish">'
    },
    {
        name: "unBooking",
        title: "已休眠",
        detail: "在特定日期前，房客無法預訂或在搜尋結果中找到此房源。",
        icon: '<img src="/icon/sleep.svg" alt="sleep">' +
            ''
    },
    {
        name: "unBooking",
        title: "取消發布",
        detail: "房客無法預訂或在搜尋結果中找到此房源。",
        icon: '<img src="/icon/UnPublished.svg" alt="unPublish">'
    },
    {
        name: "unBooking",
        title: "下架",
        detail: "將你的房源從 Airbnb 永久下架。",
        icon: '<img src="/icon/RemovePublish.svg" alt="removePublish">'
    },
];
let description = [
    {title: "房源空間", detail: "提供房源與房型的概述，讓房客對房源有初步的了解。"},
    {title: "房客使用權限", detail: "讓房客知道在附近街區行動的方法，以及停車情況。"},
    {title: "其他注意事項", detail: "提供沒有在其他部分列明，而你希望潛在房客在預訂前知道的特殊事項。"}
];
let address = ["街道", "公寓、套房門牌號碼（選填）", "城市", "州", "郵遞區號"];
let typeSelect = [
    {
        title: "哪個類型與您的房源最相符？",
        category: ["公寓", "獨棟房屋", "附屬建築", "獨特房源", "家庭式旅館", "精品旅館"]
    },
    {
        title: "住宿類型",
        houseType: {
            "公寓": ["出租大樓", "私有公寓", "loft", "出租大樓", "服務式公寓", "古巴家庭旅館"],
            "獨棟房屋": ["住宅", "小木屋", "別墅", "連棟房屋", "村舍", "生態土屋", "船屋", "小屋", "農場住宿", "度假小木屋", "平房"],
            "附屬建築": ["客用住房", "客用套房", "農場住宿"],
            "獨特房源": ["穀倉", "小船", "公車", "露營車", "樹屋", "營地", "沙堡", "洞穴", "冰屋", "小島", "牧場", "宗教建築", "貨櫃屋", "帳篷", "火車", "蒙古包", "其他"],
            "家庭式旅館": ["家庭式旅館", "自然小屋", "臺灣民宿", "農場住宿"],
            "精品旅館": ["精品旅店", "自然小屋", "青年旅館", "服務式公寓", "公寓式旅店", "飯店", "渡假村"]
        }
    },
    {
        title: "房源類型",
        roomCategory: ["整套房源", "獨立房間", "合住房間"]
    }
];
let facility = {
    "衛浴": ["浴缸", "坐浴盆", "沐浴乳", "清潔產品", "潤髮乳", "吹風機", "熱水", "戶外淋浴空間", "洗髮露", "沐浴乳"],
    "臥室和洗衣": ["生活必需品", "床單", "衣櫥", "乾衣機", "曬衣架", "額外的枕頭和毛毯", "衣架", "熨斗", "蚊帳", "遮光窗簾", "衣架", "洗衣機"],
    "娛樂": ["書籍與讀物", "網路連線", "運動器材", "遊戲主機", "鋼琴", "乒乓球桌", "撞球桌", "黑膠唱片機", "音響系統", "電視"],
    "親子": ["嬰兒浴盆", "嬰兒監視器", "嬰兒安全門欄", "臨時保母推薦", "桌遊", "尿布台", "童書與玩具", "兒童餐具", "嬰兒床", "壁爐護欄", "兒童高腳椅", "插座蓋", "遊戲床/旅行用嬰兒床", "桌角防護", "窗栅"],
    "暖氣和冷氣": ["空調設備", "吊扇", "暖氣", "室內壁爐", "移動式電扇"],
    "居家安全": ["一氧化碳警報器", "滅火器", "急救包", "帶鎖的臥室", "煙霧警報器"],
    "網路和辦公": ["專門工作空間", "隨身WiFi", "無線網路"],
    "廚房和餐飲": ["烤盤", "燒烤用具", "麵包機", "調理機", "咖啡", "咖啡機", "基本廚具", "餐桌", "盤子和餐具", "洗碗機", "冷凍庫", "熱水壺", "廚房", "微波爐", "小冰箱", "烤箱", "冰箱", "電鍋", "爐子", "烤麵包機", "壓縮式垃圾桶", "葡萄酒杯"],
    "位置特色": ["直達海灘", "湖畔", "附近有自助洗衣店", "獨立入口", "度假村入場證", "水岸"],
    "戶外": ["後院", "烤肉區", "沙灘必備物品", "自行車", "船舷梯", "火坑", "吊床", "小輕艇", "戶外用餐區", "戶外家具", "戶外廚房", "庭院或陽台"],
    "停車位和設施": ["電梯", "電動汽車（EV）充電設備", "建築物內免費停車", "路邊有免費停車位", "健身房", "按摩浴池", "建築物範圍外有收費停車", "建築物內有收費停車位", "游泳池", "獨立客廳", "三溫暖", "獨立房屋"],
    "服務": ["早餐", "退房前需打掃", "可長期住宿", "可存放行李"]
}
let space = {
    canUse: {
        title: "房客可以使用哪些區域？",
        detail: ["臥室", "全套衛浴", "廁所", "全套廚房", "小廚房", "客廳", "用餐區域", "辦公室", "後院", "庭院", "游泳池", "按摩浴池", "洗衣間", "車庫", "健身房", "室外空間"]
    },
    bedroom: {
        title: "臥室",
        check: ["與其他房客共用", "附設獨立衛浴"],
        detail: ["小號雙人床", "標準雙人床", "傳統單人床", "沙發床", "加大雙人床", "標準單人床", "小型沙發床", "雙層床", "地板床墊", "充氣床墊", "嬰兒床", "幼兒床", "吊床", "水床"]
    },
    share: {
        title: "會和誰共用這些空間？",
        check: ["我", "好友、家人或室友", "其他房客"]
    }
}

let lastBar = '';
barBtn.forEach(item => {
    // 初始化
    if (lastBar == '') {
        lastBar = detailSection;
        document.getElementById('detailBtn').classList.add('active');
    }
    item.addEventListener('click', (e) => {
        barBtn.forEach(btn => btn.classList.remove('active'))

        lastBar.classList.add('d-none');

        if (e.target.getAttribute('id') === 'detailBtn') {
            detailSection.classList.remove('d-none');
            e.target.classList.add('active');
            lastBar = detailSection;
        } else if (e.target.getAttribute('id') === 'priceBtn') {
            priceSection.classList.remove('d-none');
            e.target.classList.add('active');
            lastBar = priceSection;
        } else {
            policySection.classList.remove('d-none');
            e.target.classList.add('active');
            lastBar = policySection;
        }
    });
});

let activeContent;
let commonBtn = document.querySelectorAll('.commonBtn');
commonBtn.forEach(btn => {
    btn.addEventListener('mousedown', function (e) {
        let limitNumber = 0;
        let component = document.createElement('common-component');
        let input = component.shadowRoot.querySelector('input');
        let textarea = component.shadowRoot.querySelector('textarea');
        let content = getParentNode(this, 2).querySelector('.content');
        let saveBtn = component.shadowRoot.querySelector('.saveBtn');
        let inputTime = component.shadowRoot.querySelector('input[type="time"]');
        let radio = component.shadowRoot.querySelector('.radio');
        let up = component.shadowRoot.querySelector('.up');

        //避免重複出現一樣的模組
        let allComponent = getParentNode(this, 2).querySelectorAll('common-component');
        if (allComponent !== undefined) {
            allComponent.forEach(x => {
                x.parentNode.removeChild(x)
            });
        }

        //按編輯時隱藏內容
        activeContent = content;

        component.classList.add('collapse');
        component.setAttribute('id', 'commonCollapse');
        component.shadowRoot.querySelector('.com-title').innerText = getParentNode(this, 2).querySelector('.subtitle').innerText;
        component.shadowRoot.querySelector('span').innerText = this.parentNode.querySelector('span').innerText;

        //是否啟用Textarea
        if (this.getAttribute('textarea') !== null) {
            textarea.style.display = 'block';
            input.style.display = 'none';
        }

        //是否啟用Time
        if (this.getAttribute('time') !== null) {
            inputTime.style.display = 'block';
            input.style.display = 'none';
        }

        //是否啟用Radio & 動態生成資料
        if (this.getAttribute('radio') !== null) {
            radio.style.display = 'block';
            input.style.display = 'none';
            let data = [];
            if (e.target.getAttribute('data') === 'instanceBooking') data = instanceBooking;
            else if (e.target.getAttribute('data') === 'unBooking') data = unBooking;
            else if (e.target.getAttribute('data') === 'status') data = status;


            data.forEach((item, index) => {
                let list = document.createElement('div').cloneNode(true);
                let input = document.createElement('input');
                let label = document.createElement('label');
                let span = document.createElement('span');
                let iconSpan = document.createElement('div');
                let p = document.createElement('p');
                list.classList.add('list');
                input.setAttribute('type', 'radio');
                input.setAttribute('id', `${item.name}${index}`);
                input.setAttribute('name', `${item.name}`);
                label.setAttribute('for', `${item.name}${index}`);
                span.innerText = item.title;
                p.innerText = item.detail;

                if (e.target.getAttribute('data') === 'status') {
                    iconSpan.innerHTML += item.icon;
                }

                iconSpan.appendChild(span);
                label.appendChild(iconSpan);
                label.appendChild(p);
                list.appendChild(input);
                list.appendChild(label);
                component.shadowRoot.querySelector('.radio').appendChild(list);
            });
            //初始化radio
            component.shadowRoot.querySelectorAll('.radio span').forEach(x => {
                if (x.innerText == getParentNode(e.target, 2).querySelector('.content').innerText) {
                    getParentNode(x, 3).querySelector('input').checked = true
                }
            });
        }

        //房間詳情
        if (this.getAttribute('description') !== null) {
            description.forEach(item => {
                let div = document.createElement('div');
                let textbox = document.createElement('textarea');
                let h4 = document.createElement('h4');
                let span = document.createElement('span');
                div.classList.add('description');
                h4.innerText = item.title;
                span.classList.add('com-description');
                span.innerText = item.detail;

                div.appendChild(h4);
                div.appendChild(span);
                div.appendChild(textbox);
                component.shadowRoot.querySelector('.up').appendChild(div);
            })
        }

        //地址
        if (this.getAttribute('address') !== null) {
            input.style.display = 'none';
            address.forEach(item => {
                let div = document.createElement('div');
                let input = document.createElement('input');
                let span = document.createElement('span');
                div.classList.add('address');
                span.innerText = item;

                div.appendChild(span);
                div.appendChild(input);
                component.shadowRoot.querySelector('.up').appendChild(div);
            })
        }

        //房源與房型
        if (this.getAttribute('select') !== null) {
            input.style.display = 'none';
            typeSelect.forEach((item, i) => {
                let div = document.createElement('div');
                let select = document.createElement('select');
                let span = document.createElement('span');
                div.classList.add('select');
                span.innerText = item.title;

                if (i == 0) {
                    typeSelect[i].category.forEach(x => {
                        createOption(x, select);
                    });
                }

                if (i == 1) {
                    component.shadowRoot.querySelector('select').addEventListener("change", (e) => {
                        select.innerHTML = "";
                        typeSelect[i].houseType[`${e.target.value}`].forEach(x => {
                            createOption(x, select);
                        });
                    });
                }

                if (i == 2) {
                    typeSelect[i].roomCategory.forEach(x => {
                        createOption(x, select);
                    });
                }

                div.appendChild(span);
                div.appendChild(select);
                component.shadowRoot.querySelector('.up').appendChild(div);
            });
        }

        //price區域
        if (this.getAttribute('price') !== null) {
            if (this.getAttribute('percent') !== null) {
                component.shadowRoot.querySelector('.com-price span').style.display = 'block';
            } else {
                component.shadowRoot.querySelector('.com-price p').style.display = 'block';
            }
            activeContent.parentNode.style.opacity = '0';
        }

        //Time & textarea初始值
        if (content.innerText === "未設定" || content.innerText === "選擇時間" || content.innerText == null) {
            input.value = '';
            textarea.value = '';
            inputTime.value = '';
        } else {
            input.value = content.innerText;
            textarea.value = content.innerText;
            inputTime.value = content.innerText;
        }

        //字數限制
        if (this.getAttribute('num') !== null)
            limitNumber = Number(this.getAttribute('num'));
        else
            component.shadowRoot.querySelector('.com-length').style.display = 'none';
        component.shadowRoot.querySelector('.start').innerText = input.value.length;
        component.shadowRoot.querySelector('.end').innerText = limitNumber;

        input.addEventListener('input', function () {
            component.shadowRoot.querySelector('.start').innerText = this.value.length;
            //price只能輸入數字
            if (e.target.getAttribute('price') !== null) {
                this.value = this.value.replace(/\D/g, '');
                if (e.target.getAttribute('percent') !== null) {
                    //待解決
                    if (Number(this.value) > 100 || Number(this.value) < 0) saveBtn.style.display = 'none';
                    else saveBtn.style.display = 'block';
                }
            }

            if (this.value.length > limitNumber && limitNumber !== 0) {
                input.classList.add('limit');
                saveBtn.classList.add('disabled');
                saveBtn.disabled = true;
            } else {
                input.classList.remove('limit');
                saveBtn.classList.remove('disabled');
                saveBtn.disabled = false;
            }
        });

        //儲存
        saveBtn.addEventListener('click', (event) => {
            content.innerText = "";
            if (e.target.getAttribute('textarea') !== null)
                content.innerText = textarea.value;
            else if (e.target.getAttribute('time') !== null)
                content.innerText = inputTime.value;
            else if (e.target.getAttribute('radio') !== null) {
                radio.querySelectorAll('input').forEach(x => {
                    if (x.checked) {
                        content.innerHTML = x.nextSibling.querySelector('div').innerHTML;
                        if (e.target.getAttribute('data') === 'status')
                            document.getElementById('showStatus').innerHTML = content.innerHTML;
                        else if (e.target.getAttribute('data') === 'instanceBooking')
                            document.getElementById('showInstance').innerHTML = content.innerHTML;
                    }
                })
            } else if (e.target.getAttribute('address') !== null) {
                up.querySelectorAll('input').forEach(x => {
                    if (x.value !== "")
                        content.innerText += `${x.value},`
                });
            } else if (e.target.getAttribute('select') !== null) {
                up.querySelectorAll('select').forEach(x => {
                    content.innerText += `${x.value},`
                });
            } else
                content.innerText = input.value;

            destroyNode(event, 'commonCollapse');
        });

        getParentNode(this, 2).appendChild(component);

    }, false);
})

//設備與服務
let facilityBody = document.getElementById('facilityBody');
document.querySelector('.facilityBtn').addEventListener('click', () => {
    Object.keys(facility).forEach((x, index) => {
        let div = document.createElement('div');
        let h3 = document.createElement('h3');
        h3.innerText = x;
        div.appendChild(h3);
        facility[x].forEach((item, i) => {
            let list = document.createElement('div');
            let span = document.createElement('span');
            let group = document.createElement('div');
            let noInput = document.createElement('input');
            let yesInput = document.createElement('input');
            let noLabel = document.createElement('label');
            let yesLabel = document.createElement('label');
            span.innerText = item;
            list.classList.add('modal-list');
            setAttributes(group, {"class": "btn-group btn-group-justified", "data-toggle": "buttons"});
            setAttributes(noInput, {
                "type": "radio",
                "class": "btn-check",
                "name": `${index + 1}-${i + 1}`,
                "id": `no-${index + 1}-${i + 1}`,
                "autocomplete": "off"
            });
            setAttributes(noLabel, {"class": "btn btn-outline-dark editBtn", "for": `no-${index + 1}-${i + 1}`});
            setAttributes(yesInput, {
                "type": "radio",
                "class": "btn-check yesInput",
                "name": `${index + 1}-${i + 1}`,
                "id": `yes-${index + 1}-${i + 1}`,
                "autocomplete": "off"
            });
            setAttributes(yesLabel, {"class": "btn btn-outline-dark editBtn", "for": `yes-${index + 1}-${i + 1}`});
            noLabel.innerText = "✕";
            yesLabel.innerText = "✓";

            group.appendChild(noInput);
            group.appendChild(noLabel);
            group.appendChild(yesInput);
            group.appendChild(yesLabel);
            list.appendChild(span);
            list.appendChild(group);
            div.appendChild(list);
        });
        facilityBody.appendChild(div);
    });

    let content = document.querySelector('.facility .content');
    let saveBtn = document.getElementById('facility-save');
    saveBtn.addEventListener('click', () => {
        content.innerText = "";
        facilityBody.querySelectorAll('.yesInput').forEach(x => {
            if (x.checked) {
                content.innerText += `${getParentNode(x, 2).querySelector('span').innerText},`;
            }
        })
    });
});

//房間與空間
let spaceBody = document.getElementById('spaceBody');
document.querySelector('.spaceBtn').addEventListener('click', () => {
    Object.keys(space).forEach((x, index) => {
        let div = document.createElement('div');
        let h4 = document.createElement('h4');
        h4.innerText = space[x].title;
        div.appendChild(h4);
        if (index == 0) div.classList.add('canUse');
        else if (index == 1) div.classList.add('bedCount');

        if (space[x].check !== undefined) {
            space[x].check.forEach(item => {
                let list = document.createElement('div');
                let input = document.createElement('input');
                let label = document.createElement('label');
                list.classList.add('form-check');
                label.innerText = item;
                setAttributes(input, {"class": "form-check-input", "type": "checkbox", "id": `${x}-${index + 1}`});
                setAttributes(label, {"class": "form-check-label", "for": `${x}-${index + 1}`});

                list.appendChild(input);
                list.appendChild(label);
                div.appendChild(list);
            });
        }
        if (space[x].detail !== undefined) {
            space[x].detail.forEach(item => {
                let list = document.createElement('div');
                let span = document.createElement('span');
                let button = document.createElement('div');
                let minus = document.createElement('button');
                let plus = document.createElement('button');
                let num = document.createElement('span');
                list.classList.add('list');
                button.classList.add('btn');
                minus.addEventListener('click', (e) => {
                    let span = e.target.parentNode.querySelector('span');
                    span.innerText = Number(span.innerText) - 1;
                    if (span.innerText < 0) span.innerText = 0;
                });
                plus.addEventListener('click', (e) => {
                    let span = e.target.parentNode.querySelector('span');
                    span.innerText = Number(span.innerText) + 1;
                });
                span.innerText = item;
                minus.innerText = '-';
                plus.innerText = '+';
                num.innerText = '0';

                button.appendChild(minus);
                button.appendChild(num);
                button.appendChild(plus);
                list.appendChild(span);
                list.appendChild(button);
                div.appendChild(list);
            });
        }
        spaceBody.appendChild(div);
    });

    let content = document.querySelector('.space .content');
    let saveBtn = document.getElementById('space-save');
    saveBtn.addEventListener('click', () => {
        let bedroom = 0;
        let bed = 0;
        let bathroom = 0;
        let otherSpace = 0;
        spaceBody.querySelectorAll('.canUse .list').forEach(x => {
            let span = x.querySelector('span').innerText;
            let num = x.lastChild.querySelector('span').innerText;
            if (span == "臥室") bedroom = num;
            else if (span == "全套衛浴") bathroom = num;
            else otherSpace += Number(num)
        })
        spaceBody.querySelectorAll('.bedCount .list').forEach(x => {

            let num = x.lastChild.querySelector('span').innerText;
            bed += Number(num)
        })
        content.innerHTML = `臥室: ${bedroom}<br/>床數：${bed}<br/>衛浴：${bathroom}<br/>其他區域：${otherSpace}<br/>`;
    });
});

//顯示更多內容
contentDiv.forEach(content => {
    var observer = new MutationObserver(function (mutations) {
        let mutation = mutations[mutations.length - 1];
        // console.log(mutation.addedNodes.length == 0)
        if (mutation.addedNodes.length !== 0) {
            if (mutation.addedNodes[0].length > 80 && !mutation.target.parentNode.querySelector('button')) {
                mutation.target.classList.add('hide');
                let button = document.createElement('button').cloneNode(true);
                button.style.marginTop = "1rem";
                button.innerText = "顯示更多";
                button.addEventListener('mousedown', (e) => {
                    if (mutation.target.getAttribute('class').includes('hide')) {
                        mutation.target.classList.remove('hide');
                        e.target.innerText = "隱藏";
                    } else {
                        mutation.target.classList.add('hide');
                        e.target.innerText = "顯示更多";
                    }
                })
                mutation.target.parentNode.appendChild(button)
            } else {
                let btn = mutation.target.parentNode.querySelector('button');
                if (btn !== null) btn.parentNode.removeChild(btn);
            }
        }
    });
    observer.observe(content, {childList: true});
});

//建立option
function createOption(x, select) {
    let option = document.createElement('option').cloneNode(true);
    option.innerText = x;
    option.value = x;
    select.appendChild(option);
}

//setAttribute
function setAttributes(el, attrs) {
    for (let key in attrs) {
        el.setAttribute(key, attrs[key]);
    }
}

//取parentNode
function getParentNode(e, num) {
    let parent = e;
    for (i = 0; i < num; i++) {
        parent = parent.parentNode;
    }
    return parent
}

//銷毀虛擬節點
function destroyNode(e, id) {
    $(`#${id}`).collapse('hide');
    e.preventDefault();
    document.querySelector(`#${id}`).addEventListener('hidden.bs.collapse', (e) => {
        e.target.parentNode.removeChild(e.target);
    })
    if (activeContent.parentNode.getAttribute('class').includes('price-mix'))
        activeContent.parentNode.style.opacity = '100';
}

//common共用組件
class CommonComponent extends HTMLElement {
    constructor() {
        super();
        var shadow = this.attachShadow({mode: 'open'});
        var templateElem = document.getElementById('common-component');
        var content = templateElem.content.cloneNode(true);
        shadow.appendChild(content);
        // 取消
        shadow.querySelectorAll('.cancel').forEach(btn => {
            btn.addEventListener('click', (e) => {
                destroyNode(e, 'commonCollapse');
            })
        })
    }
}

window.customElements.define('common-component', CommonComponent);

//房客人數增減
let minus = document.querySelectorAll('.minus');
let plus = document.querySelectorAll('.plus');
minus.forEach(x => {
    x.addEventListener('click', (e) => {
        let span = e.target.parentNode.querySelector('span');
        span.innerText = Number(span.innerText) - 1;
        if (span.innerText < 0) span.innerText = 0;
    });
});
plus.forEach(x => {
    x.addEventListener('click', (e) => {
        let span = e.target.parentNode.querySelector('span');
        span.innerText = Number(span.innerText) + 1;
    });
});

//照片拖曳監聽
let uploadDiv = document.getElementById('uploadDiv');
uploadDiv.addEventListener("drop", function (e) {
    e.preventDefault();
    let file = e.dataTransfer.files[0];
    loadPic(file)
})

// 拖曳監聽(必須)
uploadDiv.addEventListener("dragover", function (e) {
    e.preventDefault();
})

// 照片上傳監聽
let fileBtn = document.getElementById('upload_img');
fileBtn.addEventListener("change", (e) => {
    //將上傳檔案轉換為base64字串
    let file = e.target.files[0];
    loadPic(file);
})

// 照片進來後的處理
let showPhoto = document.getElementById('showPhoto');

function loadPic(file) {
    let img = new Image();
    let fr = new FileReader(); //建立FileReader物件
    fr.onload = function (e) {
        let coverBody = document.getElementById('coverBody');
        let div = document.createElement('div');
        //新增相片到所有相片
        div.classList.add('delete');
        div.style.backgroundImage = `url(${e.target.result})`
        img.src = e.target.result;
        showPhoto.appendChild(div);
        //刪除相片
        div.addEventListener('click', (e) => {
            e.target.parentNode.removeChild(e.target);
            coverBody.innerHTML = "";
            showPhoto.querySelectorAll('.delete').forEach(x => {
                coverBody.appendChild(x.cloneNode(true));
            });
        });
        //有刪除照片時封面區會先清空
        coverBody.innerHTML = "";
        //新增照片到封面區
        showPhoto.querySelectorAll('.delete').forEach(x => {
            coverBody.appendChild(x.cloneNode(true));
        });
        //封面區選擇照片
        let coverDelete = coverBody.querySelectorAll('.delete');
        coverDelete.forEach(x => {
            x.addEventListener('click', () => {
                //先清空active
                coverDelete.forEach(item => item.classList.remove('active'));
                //增加active
                x.classList.add('active');
                //封面區儲存照片
                let coverPicture = document.getElementById('coverPicture');
                document.getElementById('cover-save').addEventListener('click', () => {
                    coverPicture.querySelectorAll('.delete').forEach(x => {
                        x.parentNode.removeChild(x)
                    });
                    coverPicture.appendChild(x.cloneNode(true));
                });
            });
        });
    };
    fr.readAsDataURL(file);// 使用 readAsDataURL 將圖片轉成 Base64
    enableDragSort('drag-sort-enable');
}

//圖片移動順序
function enableDragSort(listClass) {
    const sortableLists = document.getElementsByClassName(listClass);
    Array.prototype.map.call(sortableLists, (list) => {
        enableDragList(list)
    });
}

function enableDragList(list) {
    Array.prototype.map.call(list.children, (item) => {
        enableDragItem(item)
    });
}

function enableDragItem(item) {
    item.setAttribute('draggable', true)
    item.ondrag = handleDrag;
    item.ondragend = handleDrop;
}

function handleDrag(item) {
    const selectedItem = item.target,
        list = selectedItem.parentNode,
        x = event.clientX,
        y = event.clientY;

    selectedItem.classList.add('drag-sort-active');
    let swapItem = document.elementFromPoint(x, y) === null ? selectedItem : document.elementFromPoint(x, y);
    if (list === swapItem.parentNode) {
        swapItem = swapItem !== selectedItem.nextSibling ? swapItem : swapItem.nextSibling;
        list.insertBefore(selectedItem, swapItem);
    }
}

function handleDrop(item) {
    item.target.classList.remove('drag-sort-active');
}


//相片的modal儲存改變相片及張數
let photoSave = document.getElementById('photo-save');
photoSave.addEventListener('click', () => {
    let cover = document.querySelector('#coverPicture .delete');
    let picNumber = document.querySelector('.up span');
    if (cover !== null) {
        let src = cover.style.backgroundImage
        document.querySelector('.showPic').style.backgroundImage = src;
    }
    picNumber.innerText = `(${showPhoto.querySelectorAll('.delete').length}張照片)`;
});

//sideBar
let collapse = document.querySelectorAll('.sideBtn');
let li = document.querySelectorAll('.collapse a');
collapse.forEach(item => {
    item.addEventListener('click', (e) => {
        e.target.classList.add('active');
        e.target.parentNode.querySelector('li:first-child').classList.add('active');
        collapse.forEach(x => {
            x.parentNode.querySelector('.collapsed').classList.remove('show')
        });
        li.forEach(x => {
            x.parentNode.classList.remove('active');
        });
        document.querySelectorAll('.collapsed li:first-child').forEach(x => {
            x.classList.add('active');
        });
    });
});

li.forEach(x => {
    x.addEventListener('click', (e) => {
        li.forEach(x => {
            x.parentNode.classList.remove('active')
        });
        e.target.parentNode.classList.add('active');
    })
})

//滾動時左邊子節點會改變CSS
let scroll = document.querySelectorAll('.scroll');
window.addEventListener('scroll', (e) => {
    let sTop = document.documentElement.scrollTop;
    scroll.forEach(x => {
        if (sTop > x.offsetTop - 510) {
            let h2 = x.querySelector('h2').innerText;
            li.forEach(x => {
                if (x.innerText == h2)
                    x.parentNode.classList.add('active');
            });
        } else if (sTop == 0) {
            li.forEach(x => {
                x.parentNode.classList.remove('active');
            });
            document.querySelectorAll('.collapsed li:first-child').forEach(x => {
                x.classList.add('active');
            });
        } else {
            let h2 = x.querySelector('h2').innerText;
            li.forEach(x => {
                if (x.innerText == h2)
                    x.parentNode.classList.remove('active');
            });
        }
    });
});
