<template>
  <div class="row billingTitle">帳單地址</div>

  <div class="form-floating">
    <input type="text" class="form-control" id="address" />
    <label for="address">街道地址</label>
  </div>
  <div class="form-floating">
    <input type="text" class="form-control" id="number" />
    <label for="number">公寓或套房號碼</label>
  </div>
  <div class="form-floating">
    <input type="text" class="form-control" id="town" />
    <label for="town">城市</label>
  </div>
  <div class="row">
    <div class="col-6 form-floating">
      <input type="text" class="form-control" id="city" />
      <label for="city">省份/直轄市/州</label>
    </div>
    <div class="col-6 form-floating">
      <input type="text" class="form-control" id="zipCode" />
      <label for="zipCode">郵遞區號</label>
    </div>
  </div>
  <div class="row">
    <div class="form-floating">
      <select
        class="form-select"
        aria-label="Floating label select example"
        name="state"
        id="selectCounty"
      >
        <option selected>台灣</option>
        <option value="AF">Afghanistan 阿富汗</option>
        <option value="AL">Albania 阿爾巴尼亞</option>
        <option value="AD">Andorra 安道爾</option>
        <option value="AO">Angola 安哥拉</option>
        <option value="AI">Anguilla 安圭拉</option>
        <option value="AQ">Antarctica 南極洲</option>
        <option value="AG">ANtigua and Barbuda 安地卡及巴布達</option>
        <option value="AR">Argentina 阿根廷</option>
        <option value="AM">Armenia 亞美尼亞</option>
        <option value="AW">Aruba 阿魯巴</option>
        <option value="AU">Australia 澳大利亞</option>
        <option value="AT">Austria 奧地利</option>
        <option value="AZ">Azerbaijan 亞塞拜然</option>
        <option value="AE">United Arab Emirates 阿拉伯聯合大公國</option>
        <option value="BS">Bahamas 巴哈馬</option>
        <option value="BH">Bahrain 巴林</option>
        <option value="BD">Bangladesh 孟加拉</option>
        <option value="BB">Barbados 巴貝多</option>
        <option value="BY">Belarus 白俄羅斯</option>
        <option value="BZ">Belize 貝里斯</option>
        <option value="BE">Belgium 比利時</option>
        <option value="BJ">Benin 貝南</option>
        <option value="BM">Bermuda 百慕大</option>
        <option value="BT">Bhutan 不丹</option>
        <option value="BO">Bolivia 玻利維亞</option>
        <option value="BA">Bosnia Hercegovina 波黑</option>
        <option value="BW">Botswana 波札那</option>
        <option value="BV">Bouvet Island 布維島</option>
        <option value="BR">Brazil 巴西</option>
        <option value="BN">Brunei Darussalam 汶萊</option>
        <option value="BG">Bulgaria 保加利亞</option>
        <option value="BF">Burkina Faso 布其納法索</option>
        <option value="BI">Burundi 蒲隆地</option>
        <option value="CM">Cameroon 喀麥隆</option>
        <option value="CA">Canada 加拿大</option>
        <option value="CV">Cape Verde,Republic of 維德角</option>
        <option value="CF">The Central African Republic 中非共和國</option>
        <option value="CL">Chile 智利</option>
        <option value="CN">China 中國</option>
        <option value="CX">Christmas Island 聖誕島</option>
        <option value="CC">COCOS Islands 可可島</option>
        <option value="CN">China 中國</option>
        <option value="CO">Colombia 哥倫比亞</option>
        <option value="CH">tzerland 瑞士</option>
        <option value="CG">Congo 剛果</option>
        <option value="CK">Cook Island 庫克群島</option>
        <option value="CR">Costa rica 哥斯大黎加</option>
        <option value="CI">Lvory Coast 象牙海岸</option>
        <option value="CU">Cuba 古巴</option>
        <option value="CY">Cyprus 塞普勒斯</option>
        <option value="CZ">Czech Republic 捷克共和國</option>
        <option value="DK">Denmark 丹麥</option>
        <option value="DJ">Djibouti 吉布提</option>
        <option value="DM">Gominica 多明哥</option>
        <option value="DE">Grmany 德國</option>
        <option value="DO">Dominica 多明尼加</option>
        <option value="DZ">Algeria 阿爾及利亞</option>
        <option value="EC">Ecuador 厄瓜多</option>
        <option value="EG">Egypt 埃及</option>
        <option value="EH">West Sahara 西撒哈拉</option>
        <option value="ES">Spain 西班牙</option>
        <option value="EE">Estonia 愛沙尼亞</option>
        <option value="ET">Ethiopia 衣索比亞</option>
        <option value="FJ">Fiji 斐濟</option>
        <option value="FK">Falkland Islands 福克蘭群島</option>
        <option value="FI">Finland 芬蘭</option>
        <option value="FR">France 法國</option>
        <option value="FM">Micronesia 密克羅尼西亞</option>
        <option value="GA">Gabon 加彭</option>
        <option value="GQ">Equatorial Guinea 赤道幾內亞</option>
        <option value="GF">French Guiana 法屬蓋亞那</option>
        <option value="GM">Gambia 甘比亞</option>
        <option value="GE">Georgia 喬治亞</option>
        <option value="GH">Ghana 迦納</option>
        <option value="GI">Gibraltar 直布羅陀</option>
        <option value="GR">Greece 希臘</option>
        <option value="GL">Greenland 格陵蘭</option>
        <option value="GB">United Kingdom 英國</option>
        <option value="GD">Grenada 格瑞那達</option>
        <option value="GP">Guadeloupe 瓜德羅普</option>
        <option value="GU">Guam 關島</option>
        <option value="GT">Guatemala 瓜地馬拉</option>
        <option value="GN">Guinea 幾內亞</option>
        <option value="GW">Guinea-Bissau 幾內亞比索</option>
        <option value="GY">Guyana 蓋亞那</option>
        <option value="HR">Croatia 克羅埃西亞</option>
        <option value="HT">Haiti 海地</option>
        <option value="HN">Honduras 宏都拉斯</option>
        <option value="HK">Hong Kong 中國香港</option>
        <option value="HU">Hungary 匈牙利</option>
        <option value="IS">Iceland 冰島</option>
        <option value="IN">India 印度</option>
        <option value="ID">Indonesia 印度尼西亞</option>
        <option value="IR">Iran 伊朗</option>
        <option value="IQ">Iraq 伊拉克</option>
        <option value="IO">
          British Indian Ocean Territory 英聯邦的印度洋領域
        </option>
        <option value="IE">Ireland 愛爾蘭</option>
        <option value="IL">Israel 以色列</option>
        <option value="IT">Italy 義大利</option>
        <option value="JM">Jamaica 牙買加</option>
        <option value="JP">Japan 日本</option>
        <option value="JO">Jordan 約旦</option>
        <option value="KZ">Kazakstan 哈薩克</option>
        <option value="KE">Kenya 肯亞</option>
        <option value="KI">Kiribati 吉里巴斯</option>
        <option value="KP">North Korea 朝鮮</option>
        <option value="KR">Korea 韓國</option>
        <option value="KH">Cambodia 柬埔寨</option>
        <option value="KM">Comoros 葛摩</option>
        <option value="KW">kuwait 科威特</option>
        <option value="KG">Kyrgyzstan 吉爾吉斯斯坦</option>
        <option value="KY">Cayman Islands 開曼群島</option>
        <option value="LA">Laos 寮國</option>
        <option value="LK">Sri Lanka 斯里蘭卡</option>
        <option value="LV">Latvia 拉托維亞</option>
        <option value="LB">Lebanon 黎巴嫩</option>
        <option value="LS">Lesotho 賴索托</option>
        <option value="LR">Liberia 賴比瑞亞</option>
        <option value="LY">Libya 利比亞</option>
        <option value="LI">Liechtenstein 列支敦斯登</option>
        <option value="LT">Lithuania 立陶宛</option>
        <option value="LU">Luxembourg 盧森堡</option>
        <option value="LC">St. Lucia 聖露西亞</option>
        <option value="MO">Macao 中國澳門</option>
        <option value="MG">Malagasy 馬達加斯加</option>
        <option value="MW">Malawi 馬拉維</option>
        <option value="MY">Malaysia 馬來西亞</option>
        <option value="MV">Maldives 馬爾地夫</option>
        <option value="ML">Mali 馬裡</option>
        <option value="MT">Malta 馬耳他</option>
        <option value="MH">Marshall Islands 馬紹爾群島</option>
        <option value="MR">Mauritania 茅利塔尼亞</option>
        <option value="MU">Mauritius 模里西斯</option>
        <option value="MX">Mexico 墨西哥</option>
        <option value="MD">Moldova 摩爾多瓦</option>
        <option value="MC">Monaco 摩納哥</option>
        <option value="MN">Mongolia 蒙古</option>
        <option value="MS">Montserrat 蒙特塞拉特</option>
        <option value="MA">Morocco 摩洛哥</option>
        <option value="MZ">Mozambique 莫三比克</option>
        <option value="MM">Burma 緬甸</option>
        <option value="MP">Northern Mariana Islands 北馬里亞那群島</option>
        <option value="NA">Namibia 納米比亞</option>
        <option value="NR">Naura 諾魯</option>
        <option value="NP">Nepal 尼泊爾</option>
        <option value="NL">Netherlands 荷蘭</option>
        <option value="NT">Neutral Zone 中立區</option>
        <option value="NC">New Caledonia 新喀里多尼亞</option>
        <option value="NZ">New Zealand 紐西蘭</option>
        <option value="NI">Nicaragua 尼加拉瓜</option>
        <option value="NE">Niger 尼日</option>
        <option value="NG">Nigeria 奈及利亞</option>
        <option value="NU">Niue 紐埃</option>
        <option value="NF">Norfolk Island 諾福克島</option>
        <option value="NO">Norway 挪威</option>
        <option value="OM">Oman 阿曼</option>
        <option value="PK">Pakistan 巴基斯坦</option>
        <option value="PF">French Polynesia 法屬玻里尼西亞</option>
        <option value="PW">Palau 帛琉</option>
        <option value="PA">Panama 巴拿馬</option>
        <option value="PG">Papua,Territory of 巴布亞紐幾內亞</option>
        <option value="PY">Paraguay 巴拉圭</option>
        <option value="PE">Peru 祕魯</option>
        <option value="PH">Philippines 菲律賓</option>
        <option value="PN">Pitcairn Islands 皮特開恩群島</option>
        <option value="PL">Poland 波蘭</option>
        <option value="PT">Portugal 葡萄牙</option>
        <option value="PR">Puerto Rico 波多黎各(美)</option>
        <option value="QA">Qatar 卡達</option>
        <option value="RO">Romania 羅馬尼亞</option>
        <option value="RU">Russia 俄羅斯聯邦</option>
        <option value="RW">Rwanda 盧安達</option>
        <option value="SV">El Salvador 薩爾瓦多</option>
        <option value="SH">St.Helena 聖赫勒那</option>
        <option value="SM">San Marino 聖馬利諾</option>
        <option value="ST">Sao Tome and Principe 聖多美與普林西比</option>
        <option value="SA">Saudi Arabia 沙烏地阿拉伯</option>
        <option value="SN">Senegal 塞內加爾</option>
        <option value="SC">Seychelles 塞席爾</option>
        <option value="SL">Sierra leone 獅子山</option>
        <option value="SG">Singapore 新加坡</option>
        <option value="SK">Slovakia 斯洛伐克</option>
        <option value="SI">Slovene 斯洛維尼亞</option>
        <option value="SB">Solomon Islands 索羅門群島</option>
        <option value="SO">Somali 索馬利亞</option>
        <option value="SD">Sudan 蘇丹</option>
        <option value="SR">Surinam 蘇利南</option>
        <option value="SZ">Swaziland 史瓦濟蘭</option>
        <option value="TW">台灣</option>
      </select>
      <label for="selectCounty">國家/地區</label>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.billingTitle {
  font-weight: 500;
  font-size: 16px;
  padding: 20px 10px;
}
</style>
<script>
export default {};
</script>
