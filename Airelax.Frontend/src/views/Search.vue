<template>
  <div class="row top">
    <div class="col-md-6 col-12 position-relative ">
      <div class="back" v-if="$store.state.fullWidth<768">
        <a href="#"><img src="@/assets/image/Room/icon/back.svg"></a>
        <div class="date"> {{ StartDate }}9月1號 - {{ EndDate }}9月2號 · {{ TravelerCount }}2位房客
          <span class="between">|</span>
          <a href="#" data-bs-toggle="offcanvas" data-bs-target="#offcanvasBottom" aria-controls="offcanvasBottom"><img src="@/assets/image/Room/icon/setting.svg"></a></div>
      </div>
      <div class="px-4 pt-md-3">
        <div class="text-start m-md-4 pt-3 ">
          <p>
            {{ RoomCount }}300多間住宿 · {{ StartDate }}9月1號 - {{ EndDate }}9月2號 ·
            {{ TravelerCount }}2位房客
          </p>
          <h4>{{ City }}台北,{{ Distinct }}中和區</h4>
          <div class="d-none d-md-block">
            <div class="d-inline-block">
              <button
                type="button"
                class=" filters border border-1 bg-white p-2 text-dark btn-white rounded-pill "
                data-bs-toggle="dropdown"
                data-bs-auto-close="outside"
              >
                免費退訂
              </button>
              <div
                class="dropdown-menu mt-3"
                aria-labelledby="dropdownMenuClickableInside"
              >
                <p class="d-inline-block">僅顯示提供免費退訂的住宿</p>
                <div class="d-inline-block form-check form-switch">
                  <input
                    class="form-check-input checkbtn"
                    type="checkbox"
                    id="flexSwitchCheckDefault"
                    v-model="tax"
                  />
                </div>
                <div class="modal-footer">
                  <button
                    type="button"
                    class="btn btn-link text-dark fw-bold"
                    @click="reset"
                  >
                    清除
                  </button>
                  <button
                    type="button"
                    class="btn btn-dark"
                    data-bs-dismiss="dropdown"
                    aria-label="Close"
                  >
                    儲存
                  </button>
                </div>
              </div>
            </div>
            <div class="d-inline-block">
              <button
                type="button"
                class=" filters border border-1 bg-white p-2 text-dark btn-white rounded-pill "
                data-bs-toggle="dropdown"
                aria-expanded="false"
                data-bs-auto-close="outside"
              >
                房源類型
              </button>
              <div class="dropdown-menu mt-3">
                <div
                  v-for="(item, index) in TypeOfPlace"
                  :key="index"
                  class="type_place"
                >
                  <input
                    type="checkbox"
                    id="item.id"
                    style="width: 20px; height: 20px"
                    class=""
                    v-model="tick"
                  />
                  <label for="item.id">
                    <h6>{{ item.title }}</h6>
                    <p>{{ item.text }}</p>
                  </label>
                </div>
                <div class="modal-footer">
                  <button
                    type="button"
                    class="btn btn btn-link text-dark fw-bold"
                    @click="reset"
                  >
                    清除
                  </button>
                  <button type="button" class="btn btn-dark">儲存</button>
                </div>
              </div>
            </div>
            <div class="d-inline-block">
              <button
                type="button"
                class="
                  filters
                  border border-1
                  bg-white
                  p-2
                  text-dark
                  btn-white
                  rounded-pill
                "
                data-bs-toggle="dropdown"
                aria-expanded="false"
                data-bs-auto-close="outside"
              >
                價錢
              </button>
              <div class="dropdown-menu mt-3 px-3">
                <div class="mt-3">
                  <p>平均每晚價格為{{}}TWD</p>
                  <div>
                    <!-- 還沒寫價格分布圖表 -->
                  </div>
                  <div
                    class="
                      minPrice
                      d-inline-block
                      border border-secondary
                      rounded
                      px-2
                      py-1
                    "
                  >
                    <p>最低價格</p>
                    <div id="minPrice">{{ MinPrice }}</div>
                  </div>
                  <span class="mx-2">-</span>
                  <div
                    class="
                      maxPrice
                      d-inline-block
                      border border-secondary
                      rounded
                      px-2
                      py-1
                    "
                  >
                    <p>最高價格</p>
                    <div id="maxPrice ">{{ MaxPrice }}</div>
                  </div>
                </div>
                <div class="modal-footer">
                  <button
                    type="button"
                    class="btn btn btn-link text-dark fw-bold"
                    @click="reset"
                  >
                    清除
                  </button>
                  <button type="button" class="btn btn-dark">儲存</button>
                </div>
              </div>
            </div>
            <div class="d-inline-block">
              <button
                type="button"
                class="
                  filters
                  border border-1
                  bg-white
                  p-2
                  text-dark
                  btn-white
                  rounded-pill
                "
                data-bs-toggle="dropdown"
                aria-expanded="false"
                data-bs-auto-close="outside"
              >
                即時預訂
              </button>
              <div class="dropdown-menu">
                <h5>即時預訂</h5>
                <p class="d-inline-block">無需等待房東批准即可預訂的房源</p>
                <div class="d-inline-block form-check form-switch">
                  <input
                    class="form-check-input checkbtn"
                    type="checkbox"
                    id="flexSwitchCheckDefault"
                    v-model="tax"
                  />
                </div>
                <div class="modal-footer">
                  <button
                    type="button"
                    class="btn btn btn-link text-dark fw-bold"
                    @click="reset"
                  >
                    清除
                  </button>
                  <button type="button" class="btn btn-dark">儲存</button>
                </div>
              </div>
            </div>
            <div class="d-inline-block">
              <button
                class="filters border rounded-pill px-3 py-2 bg-transparent"
                data-bs-toggle="modal"
                data-bs-target="#exampleModal"
              >
                更多篩選條件
              </button>
              <div class="more border rounded position-absolute text-start more">
                <div
                  class="modal fade"
                  id="exampleModal"
                  tabindex="-1"
                  aria-labelledby="exampleModalLabel"
                  aria-hidden="true"
                >
                  <div class="modal-dialog modal-dialog-scrollable modal-lg">
                    <div class="modal-content">
                      <div class="modal-header">
                        <h4
                          class="modal-title fw-bolder ps-3"
                          id="exampleModalLabel"
                        >
                          更多篩選條件
                        </h4>
                        <button
                          type="button"
                          class="btn-close"
                          data-bs-dismiss="modal"
                          aria-label="Close"
                        ></button>
                      </div>
                      <div class="modal-body">
                        <div class="row px-0 pb-3 m-4">
                          <h4 class="fw-bolder mb-4">臥室和床鋪</h4>
                          <div
                            class="d-flex justify-content-between"
                            v-for="(item, index) in array"
                            :key="index"
                          >
                            <p>{{ item.title }}</p>
                            <div>
                              <button
                                class="flex-1 rounded-circle border btn_"
                                @click="item.count--"
                                v-if="item.count > 0"
                              >
                                -
                              </button>
                              <span>{{ item.count }}</span>
                              <button
                                class="flex-1 rounded-circle btnAdd border"
                                @click="item.count++"
                              >
                                +
                              </button>
                            </div>
                          </div>
                        </div>
                        <hr />
                        <div class="row px-0 pb-3 m-4 moreOptions">
                          <h4 class="fw-bolder mb-4">更多選項</h4>
                          <div class="col-6">
                            <h5>超讚房東</h5>
                            <p>向獲得認可的房東租住房源</p>
                            <a href="#" class="text-dark">了解更多</a>
                            <h5>無障礙設施</h5>
                            <p>尋找符合您行動需求的住處</p>
                            <a href="#" class="text-dark">選擇住處的無障礙設施</a>
                          </div>
                          <div class="col-6">
                            <div class="form-check form-switch">
                              <input
                                class="
                                  form-check-input
                                  checkbtn
                                  position-absolute
                                  translate-middle-y
                                "
                                type="checkbox"
                                id="flexSwitchCheckDefault"
                                v-model="tax"
                              />
                            </div>
                          </div>
                        </div>
                        <hr />
                          <div class="row px-0 pb-3 m-4">
                            <h4 class="fw-bolder mb-4">設備與服務</h4>
                            <div class="row">
                              <div class="col-6" v-for="(item, index) in optionlist[0]" :key="index">
                                <input type="checkbox" :id="item.id" v-model="tick" />
                                <label :for="item.id" class="ms-3">{{ item.title }}
                                </label>
                              </div>
                              <div class="collapse" id="collapseExample">
                                <div class="empty row">
                                  <div class="col-6" v-for="(item, index) in optionlist[1]" :key="index">
                                    <input type="checkbox" :id="item.id" v-model="tick" />
                                    <label :for="item.id" class="ms-3">{{ item.title }}
                                    </label>
                                  </div>
                                </div>
                              </div>
                              <a class="mt-3 text-dark fs-6" data-bs-toggle="collapse" href="#collapseExample" role="button"
                                aria-expanded="false" aria-controls="collapseExample">
                                點擊展開
                              </a>
                            </div>
                          </div>
                        <hr />
                        <div class="row px-0 pb-3 m-4">
                          <h4 class="fw-bolder">設備</h4>
                          <div class="row">
                            <div
                              class="col-6"
                              v-for="(item, index) in AmenitiesList"
                              :key="index"
                            >
                              <input
                                type="checkbox"
                                :id="item.id"
                                v-model="tick"
                              />
                              <label :for="item.id" class="ms-3"
                                >{{ item.title }}
                              </label>
                            </div>
                          </div>
                        </div>
                        <hr />
                        <div class="row px-0 pb-3 m-4">
                          <h4 class="fw-bolder">住宿類型</h4>
                          <div class="row">
                            <div
                              class="col-6"
                              v-for="(item, index) in PropertyTypeList[0]"
                              :key="index"
                            >
                              <input
                                type="checkbox"
                                :id="item.id"
                                v-model="tick"
                              />
                              <label :for="item.id" class="ms-3"
                                >{{ item.title }}
                              </label>
                            </div>
                            <div class="collapse" id="collapseExample">
                              <div class="empty row">
                                <div
                                  class="col-6"
                                  v-for="(item, index) in PropertyTypeList[1]"
                                  :key="index"
                                >
                                  <input
                                    type="checkbox"
                                    :id="item.id"
                                    v-model="tick"
                                  />
                                  <label :for="item.id" class="ms-3"
                                    >{{ item.title }}
                                  </label>
                                </div>
                              </div>
                            </div>
                            <a
                              class="mt-3 text-dark fs-6"
                              data-bs-toggle="collapse"
                              href="#collapseExample"
                              role="button"
                              aria-expanded="false"
                              aria-controls="collapseExample"
                            >
                              點擊展開
                            </a>
                          </div>
                        </div>
                        <hr />
                        <div class="row px-0 pb-3 m-4">
                          <h4 class="fw-bolder">住宿特色</h4>
                          <div class="row">
                            <div
                              class="col-6"
                              v-for="(item, index) in UniqueStaysList[0]"
                              :key="index"
                            >
                              <input
                                type="checkbox"
                                :id="item.id"
                                v-model="tick"
                              />
                              <label :for="item.id" class="ms-3"
                                >{{ item.title }}
                              </label>
                            </div>
                            <div class="collapse" id="collapseExample">
                              <div class="empty row">
                                <div
                                  class="col-6"
                                  v-for="(item, index) in UniqueStaysList[1]"
                                  :key="index"
                                >
                                  <input type="checkbox" :id="item.id" />
                                  <label :for="item.id" class="ms-3"
                                    >{{ item.title }}
                                  </label>
                                </div>
                              </div>
                            </div>
                            <a
                              class="mt-3 text-dark fs-6"
                              data-bs-toggle="collapse"
                              href="#collapseExample"
                              role="button"
                              aria-expanded="false"
                              aria-controls="collapseExample"
                            >
                              點擊展開
                            </a>
                          </div>
                        </div>
                        <hr />
                        <div class="row px-0 pb-3 m-4">
                          <h4 class="fw-bolder">房屋守則</h4>
                          <div class="row">
                            <div
                              class="col-6"
                              v-for="(item, index) in HouseRulesList"
                              :key="index"
                            >
                              <input
                                type="checkbox"
                                :id="item.id"
                                v-model="tick"
                              />
                              <label :for="item.id">{{ item.title }} </label>
                            </div>
                          </div>
                        </div>
                        <hr />
                        <div class="row px-0 pb-3 m-4">
                          <h4 class="fw-bolder">房東語言</h4>
                          <div class="row">
                            <div
                              class="col-6"
                              v-for="(item, index) in HostLanguageList[0]"
                              :key="index"
                            >
                              <input
                                type="checkbox"
                                :id="item.id"
                                v-model="tick"
                              />
                              <label :for="item.id" class="ms-3"
                                >{{ item.title }}
                              </label>
                            </div>
                            <div class="collapse" id="collapseExample">
                              <div class="empty row">
                                <div
                                  class="col-6"
                                  v-for="(item, index) in HostLanguageList[1]"
                                  :key="index"
                                >
                                  <input
                                    type="checkbox"
                                    :id="item.id"
                                    v-model="tick"
                                  />
                                  <label :for="item.id" class="ms-3"
                                    >{{ item.title }}
                                  </label>
                                </div>
                              </div>
                            </div>
                            <a
                              class="mt-3 text-dark fs-6"
                              data-bs-toggle="collapse"
                              href="#collapseExample"
                              role="button"
                              aria-expanded="false"
                              aria-controls="collapseExample"
                            >
                              點擊展開
                            </a>
                          </div>
                        </div>
                      </div>
                      <div class="modal-footer">
                        <button
                          type="button"
                          class="btn btn-link text-dark fw-bold"
                          @click="reset"
                        >
                          清除全部
                        </button>
                        <button
                          type="button"
                          class="btn btn-dark"
                          data-bs-dismiss="modal"
                        >
                          顯示{{ roomNub }}間住宿
                        </button>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="onlybtn">
            <button
              class="filters
                  border border-2
                  bg-white
                  py-2 px-3 mb-3
                  text-dark
                  btn-white
                  rounded-pill"
              type="button"
              data-bs-toggle="offcanvas"
              data-bs-target="#offcanvasBottom"
              aria-controls="offcanvasBottom"
            >
              篩選條件
            </button>
                <div
                  class="offcanvas offcanvas-bottom h-100"
                  tabindex="-1"
                  id="offcanvasBottom"
                  aria-labelledby="offcanvasBottomLabel"
                >
                  <div class="offcanvas-header">
                    <button
                      type="button"
                      class="btn-close text-reset"
                      data-bs-dismiss="offcanvas"
                      aria-label="Close"
                    ></button>
                    <h5 class="offcanvas-title ps-3" id="offcanvasBottomLabel">
                      篩選條件
                    </h5>
                    <button type="button" class="btn btn btn-link text-dark" @click="reset">
                      清除
                    </button>
                  </div>
                  <div class="offcanvas-body small">
                    <div class="d-inline-block">
                      <h6 class="fw-bold">房源類型</h6>
                      <div class="mt-3">
                        <div
                          v-for="(item, index) in TypeOfPlace"
                          :key="index"
                          class="type_place"
                        >
                        <div class="row">
                          <div class="col-10">
                          <label for="item.id">
                            <h6>{{ item.title }}</h6>
                            <p>{{ item.text }}</p>
                          </label>
                          </div>
                          <div class="col-1">
                          <input
                            type="checkbox"
                            id="item.id"
                            style="width: 20px; height: 20px"
                            class=""
                            v-model="tick"
                          />
                          </div>
                          </div>
                        </div>
                      </div>
                    </div>
                    <hr />
                    <div class="d-inline-block w-100">
                      <h6 class="fw-bold">即時預訂</h6>
                      <div>
                        <p class="d-inline-block">
                          無需等待房東批准即可預訂的房源
                        </p>
                        <div class="d-inline-block form-check form-switch">
                          <input
                            class="form-check-input checkbtn"
                            type="checkbox"
                            id="flexSwitchCheckDefault"
                            v-model="tax"
                          />
                        </div>
                      </div>
                    </div>
                    <hr />
                    <div class="d-inline-block w-100">
                      <h6 class="fw-bold">價格範圍</h6>
                      <div class="mt-3">
                        <h6>平均每晚價格為{{Price_Day}}TWD</h6>
                        <div>
                          <!-- 還沒寫價格分布圖表 -->
                        </div>
                        <div
                          class="
                            minPrice
                            d-inline-block
                            border border-secondary
                            rounded
                            px-5
                            py-3
                          "
                        >
                          <p>最低價格</p>
                          <div id="minPrice">{{ MinPrice }}</div>
                        </div>
                        <span>-</span>
                        <div
                          class="
                            maxPrice
                            d-inline-block
                            border border-secondary
                            rounded
                            px-5
                            py-3
                          "
                        >
                          <p>最高價格</p>
                          <div id="maxPrice ">{{ MaxPrice }}</div>
                        </div>
                      </div>
                    </div>
                    <hr />
                    <div class="d-inline-block w-100">
                      <h6 class="fw-bold">臥室和床鋪</h6>
                      <div class="mt-3 row">
                        <div
                          class="d-flex justify-content-between bed"
                          v-for="(item, index) in array"
                          :key="index"
                        >
                          <p>{{ item.title }}</p>
                          <div class="col.2 ">
                            <button
                              class="flex-1 rounded-circle border btn_"
                              @click="item.count--"
                              v-if="item.count > 0"
                            >
                              -
                            </button>
                            <span mb-2>{{ item.count }}</span>
                            <button
                              class="flex-1 rounded-circle btnAdd border"
                              @click="item.count++"
                            >
                              +
                            </button>
                          </div>
                        </div>
                      </div>
                    </div>
                    <hr />
                    <div class="d-inline-block w-100">
                      <h6 class="fw-bold">退訂彈性</h6>
                      <div class="mt-3">
                        <p class="d-inline-block">僅顯示提供免費退訂的住宿</p>
                        <div class="d-inline-block form-check form-switch">
                          <input
                            class="form-check-input checkbtn ms-5"
                            type="checkbox"
                            id="flexSwitchCheckDefault"
                            v-model="tax"
                          />
                        </div>
                      </div>
                    </div>
                    <hr />
                    <div class="d-inline-block w-100">
                      <h6 class="fw-bold">更多選項</h6>
                      <div class="mt-3">
                        <h6>超讚房東</h6>
                        <p class="d-inline-block">向獲得認可的房東租住房源</p>
                        <div class="d-inline-block form-check form-switch">
                          <input
                            class="form-check-input checkbtn ms-5"
                            type="checkbox"
                            id="flexSwitchCheckDefault"
                            v-model="tax"
                          />
                        </div>
                      </div>
                    </div>
                    <hr />
                    <div class="d-inline-block">
                      <h6 class="fw-bold">設備與服務</h6>
                      <div class="mt-3">
                          <div class="collapse" id="collapseExample">
                                <div class="empty row">
                                  <div  v-for="(item, index) in optionlist[0]" :key="index">
                                    <input type="checkbox" :id="item.id" v-model="tick" />
                                    <label :for="item.id" class="ms-3">{{ item.title }}
                                    </label>
                                  </div>
                                </div>
                              </div>
                          <div class="collapse" id="collapseExample">
                                <div class="empty row">
                                  <div v-for="(item, index) in optionlist[1]" :key="index">
                                    <input type="checkbox" :id="item.id" v-model="tick" />
                                    <label :for="item.id" class="ms-3">{{ item.title }}
                                    </label>
                                  </div>
                                </div>
                              </div>
                          <a class="mt-3 text-dark fs-6" data-bs-toggle="collapse" href="#collapseExample" role="button"
                            aria-expanded="false" aria-controls="collapseExample">
                            點擊展開
                          </a>
                      </div>
                    </div>
                    <hr/>
                    <div class="d-inline-block">
                      <h6 class="fw-bold">設備</h6>
                      <div class="mt-3">
                          <div class="collapse" id="collapseExample">
                                <div class="empty row">
                                  <div  v-for="(item, index) in AmenitiesList" :key="index">
                                    <input type="checkbox" :id="item.id" v-model="tick" />
                                    <label :for="item.id" class="ms-3">{{ item.title }}
                                    </label>
                                  </div>
                                </div>
                              </div>
                          <a class="mt-3 text-dark fs-6" data-bs-toggle="collapse" href="#collapseExample" role="button"
                            aria-expanded="false" aria-controls="collapseExample">
                            點擊展開
                          </a>
                      </div>
                    </div>
                    <hr/>
                    <div class="d-inline-block">
                      <h6 class="fw-bold">住宿類型</h6>
                      <div class="mt-3">
                          <div class="collapse" id="collapseExample">
                                <div class="empty row">
                                  <div  v-for="(item, index) in PropertyTypeList[0]" :key="index">
                                    <input type="checkbox" :id="item.id" v-model="tick" />
                                    <label :for="item.id" class="ms-3">{{ item.title }}
                                    </label>
                                  </div>
                                </div>
                              </div>
                          <a class="mt-3 text-dark fs-6" data-bs-toggle="collapse" href="#collapseExample" role="button"
                            aria-expanded="false" aria-controls="collapseExample">
                            點擊展開
                          </a>
                      </div>
                    </div>
                    <hr/>
                    <div class="d-inline-block">
                      <h6 class="fw-bold">特色住宿</h6>
                      <div class="mt-3">
                          <div class="collapse" id="collapseExample">
                                <div class="empty row">
                                  <div  v-for="(item, index) in UniqueStaysList[0]" :key="index">
                                    <input type="checkbox" :id="item.id" v-model="tick" />
                                    <label :for="item.id" class="ms-3">{{ item.title }}
                                    </label>
                                  </div>
                                </div>
                              </div>
                          <a class="mt-3 text-dark fs-6" data-bs-toggle="collapse" href="#collapseExample" role="button"
                            aria-expanded="false" aria-controls="collapseExample">
                            點擊展開
                          </a>
                      </div>
                    </div>
                    <hr/>
                    <div class="d-inline-block">
                      <h6 class="fw-bold">房屋守則</h6>
                      <div class="mt-3">
                          <div
                              v-for="(item, index) in HouseRulesList"
                              :key="index"
                            >
                              <input
                                type="checkbox"
                                :id="item.id"
                                v-model="tick"
                              />
                              <label :for="item.id">{{ item.title }} </label>
                            </div>
                      </div>
                    </div>
                    <hr/>
                    <div class="d-inline-block">
                      <h6 class="fw-bold">房東語言</h6>
                      <div class="mt-3">
                          <div class="collapse" id="collapseExample">
                                <div class="empty row">
                                  <div  v-for="(item, index) in HostLanguageList[0]" :key="index">
                                    <input type="checkbox" :id="item.id" v-model="tick" />
                                    <label :for="item.id" class="ms-3">{{ item.title }}
                                    </label>
                                  </div>
                                </div>
                              </div>
                          <a class="mt-3 text-dark fs-6" data-bs-toggle="collapse" href="#collapseExample" role="button"
                            aria-expanded="false" aria-controls="collapseExample">
                            點擊展開
                          </a>
                      </div>
                    </div>
                    <div class="sticky-top">
                      <hr>
                      <button type="button" class="btn btn-dark w-100">顯示結果</button>
                    </div>
                  </div>
                </div>
          </div>
          <div class="my-2 fs-6">顯示「{{}}」的搜尋結果</div>
        </div>
        <div class="RoomType">
              <div class="col-12" v-if="get">
                  <ResultRoom :rooms="rooms" :nightCount="nightCount"></ResultRoom>
              </div>
        </div>
        <div class="page d-flex justify-content-center ">
            <nav aria-label="Page navigation example d-block">
              <ul class="pagination rounded-circle ">
                <li class="page-item"><a class="page-link text-dark border border-white" href="#"><i class="fas fa-angle-left"></i></a></li>
                <li class="page-item"><a class="page-link text-dark rounded-circle border border-white" href="#">1</a></li>
                <li class="page-item"><a class="page-link text-dark rounded-circle border border-white" href="#">2</a></li>
                <li class="page-item"><a class="page-link text-dark rounded-circle border border-white" href="#">3</a></li>
                <li class="page-item"><a class="page-link text-dark rounded-circle border border-white" href="#">4</a></li>
                <li class="page-item"><a class="page-link text-dark rounded-circle border border-white" href="#">5</a></li>
                <li class="page-item"><a class="page-link text-dark border border-white" href="#"><i class="fas fa-angle-right"></i></a></li>
              </ul>
            </nav>
        </div>
        <div>1-{{PageNum}}共{{RoomNums}}間住宿</div>
        <div class="my-4 text-secondary ">需要支付額外費用。可能會加收稅費。</div>
      </div>
      <div class="Result">
        <div class="col-12" v-if="get">
            <BrowsingRecord :rooms="rooms" :nightCount="nightCount"></BrowsingRecord>
        </div>
      </div>
    </div>
    <div class="col-6" v-if="$store.state.fullWidth>768">
      <img src="https://images.pexels.com/photos/981153/pexels-photo-981153.jpeg?auto=compress&cs=tinysrgb&dpr=3&h=750&w=1260" class="w-100 fake">
    </div>
  </div>
</template>

<script>
import axios from "axios";
import ResultRoom from '../components/Search/ResultRoom';
import BrowsingRecord from '../components/Search/BrowsingRecord';
export default {
  created() {
    axios
      .get(
        "https://raw.githubusercontent.com/Airelax/Airelax.Frontend/SHOP-48/fake-search-data.json"
      )
      .then((res) => {
        this.rooms = res.data;
        this.get = true;
      });
  },
  mounted(){
      const vm = this;
      window.addEventListener("scroll", function() {
          let top = document.documentElement.scrollTop;
          let back = this.document.querySelector('.back');
          if (back !== null){
            if(top>1 && vm.$store.state.fullWidth<768)
              back.classList.add('fixed');
            else
              back.classList.remove('fixed');
          }
      });
  },
  components:{ResultRoom, BrowsingRecord},
  data() {
    return {
      rooms: Array,
      nightCount: 3,
      get: false,
      TypeOfPlace: [
        {
          id: "EntirePlace",
          title: "整個房源",
          text: "無需與他人分享共住，可以獨享整個房源",
        },
        {
          id: "PrivateRoom",
          title: "獨立房間",
          text: "獨立房間擁有自己的房間，但與別人共用其他的空間",
        },
        {
          id: "HotelRoom",
          title: "飯店房間",
          text: "飯店房間在精品旅店、青年旅舍等更多選擇搜尋獨立或合住房間",
        },
        {
          id: "SharedRoom",
          title: "合住房間",
          text: "入住共用房源，如公共休息室",
        },
      ],
      array: [
        { title: "床位", count: 0 },
        { title: "臥室", count: 0 },
        { title: "衛浴", count: 0 },
      ],
      optionlist: [
        [
          { id: "kitchen", title: "廚房" },
          { id: "heating", title: "暖氣" },
          { id: "air", title: "空調設備" },
          { id: "washer", title: "洗衣機" },
        ],
        [
          { id: "dryer", title: "乾衣機" },
          { id: "Wi-Fi", title: "無線網路" },
          { id: "breakfast", title: "早餐" },
          { id: "hairdryer", title: "吹風機" },
          { id: "workspace", title: "專門工作空間" },
          { id: "TV", title: "電視機" },
          { id: "highchair", title: "兒童高腳椅" },
          { id: "self", title: "自助入住" },
          { id: "alarm", title: "煙霧警報器" },
          { id: "alarm2", title: "獨立衛浴" },
          { id: "Beachfront", title: "濱海" },
          { id: "Waterfront", title: "濱水" },
        ],
      ],
      AmenitiesList: [
        { id: "parking", title: "建築物內免費停車" },
        { id: "gym", title: "健身房" },
        { id: "tub", title: "按摩浴池" },
        { id: "pool", title: "游泳池" },
      ],
      PropertyTypeList: [
        [
          { id: "House", title: "獨棟房屋" },
          { id: "Apartment", title: "公寓" },
          { id: "Familyhouse", title: "家庭式旅館" },
          { id: "Boutiquehotel", title: "精品旅店" },
        ],
        [
          { id: "Loft", title: "Loft空間" },
          { id: "Villa", title: "別墅" },
          { id: "Guesthouse", title: "客用住房" },
          { id: "Guestsuite", title: "客用套房" },
          { id: "Cabin", title: "小木屋" },
          { id: "Bungalow", title: "平房" },
          { id: "Servicedapartment", title: "服務式公寓" },
          { id: "Condominium", title: "私有公寓" },
          { id: "Hostel", title: "連棟房屋" },
          { id: "Townhouse", title: "青年旅舍" },
          { id: "Hotel", title: "飯店" },
        ],
      ],
      UniqueStaysList: [
        [
          { id: "Barn", title: "小屋" },
          { id: "Camper", title: "帳篷" },
          { id: "Cave", title: "洞穴" },
          { id: "Hut", title: "穀倉" },
        ],
        [
          { id: "Minsu", title: "臺灣民宿" },
          { id: "Tent", title: "迷你屋" },
          { id: "Tiny house", title: "露營車／休旅車" },
        ],
      ],
      HouseRulesList: [
        { id: "PetsAllowed", title: "可攜帶寵物" },
        { id: "SmokingAllowed", title: "可吸菸" },
      ],
      HostLanguageList: [
        [
          { id: "English", title: "英文" },
          { id: "French", title: "法文" },
          { id: "German", title: "德文" },
          { id: "Japanese", title: "日文" },
        ],
        [
          { id: "Italian", title: "義大利語" },
          { id: "Russian", title: "俄語" },
          { id: "Spanish", title: "西班牙語" },
          { id: "Chinese", title: "中文(簡體)" },
          { id: "Arabic", title: "阿拉伯語" },
          { id: "Turkish", title: "土耳其語" },
          { id: "Indonesian", title: "印尼語" },
          { id: "Korean", title: "韓語" },
          { id: "Bengali", title: "孟加拉語" },
          { id: "Thai", title: "泰語" },
          { id: "Malay", title: "馬來語" },
          { id: "Tagalog", title: "他家祿語" },
          { id: "Norwegian", title: "挪威語" },
          { id: "Czech", title: "捷克語" },
        ],
      ],

      tax: "",
      tick: [],
      
    };
  },
  methods: {
    reset() {
      this.tax = null;
      this.tick = [];
      this.count = null;
      this.array = [
        { title: "床位", count: 0 },
        { title: "臥室", count: 0 },
        { title: "衛浴", count: 0 },
      ];
    },
    save() {},
  },
};
</script>

<style scoped lang="scss">
.back{
  width: 100%;
  top: 0;
  left: 0;
  display: flex;
  justify-content: space-around;
  align-items: center;
  padding: 1.5rem 0;
  background-color: #fff;
  border-bottom: 1px solid rgb(197, 197, 197);
  z-index: 100;
  &.fixed{
    position: fixed;
  }
  a{
    display: flex;
  }
  img{
    width: 1.2rem;
    cursor: pointer;
    margin: auto;
  }
  .date{
    display: flex;
  }
  .between{
    margin: 0 0.5rem;
  }
}
.btn-dark{
    border-radius: 8px;
  }
.position-relative{
  padding: 0;
}
.record{
      background-color: #f7f7f7;
  }
.text-start{
  p{
    font-size: 0.9rem;
  }
  h4{
    font-size: 1.5em;
    font-weight: 700;
    margin: 1rem 0;
  }
}
.type_place{
  p{
    color: rgb(150, 150, 150);
  }
}
.onlybtn{
  .checkbtn{
    font-size: 30px;
    margin: 20px 20px -10px 5px;
    line-height: 10;
    background-color: #ccc;
    border-color: #ccc;
    box-shadow: 3px 3px 5px #fff;
    &:checked {
      background-color: #717171;
      border-color: #717171;
      box-shadow: 3px 3px 5px #cccccc;
      
    }
  }
  .bed{
    .btn_ {
    width: 40px;
    height: 40px;
    background: transparent;
    border: 1px solid #717171;
    font-size: 25px;
    font-weight: bolder;
    color: #717171;
    margin-right: 20px;
  }
  .btnAdd {
    width: 40px;
    height: 40px;
    background: transparent;
    border: 1px solid #717171;
    font-size: 15px;
    font-weight: bolder;
    color: #717171;
    margin-left: 20px;
    
  }
  }
}
@media screen and (min-width: 768px) {
  .fake{
    height: 40rem;
    object-fit: cover;
  }
  .top{
    margin-right: 0 !important;
    margin-top: 5rem;
  }
  .Result{
    .col-12{
      background-color: #f7f7f7;
    }
  }
  .record{
    padding-left: 2rem;
  }
  .position-relative{
    padding: 0 ;
    overflow: auto;
    height: 40rem;
    &::-webkit-scrollbar {
      display: none;
    }
  }
  .text-start{
    margin: 0 !important;
  }
  .onlybtn {
    display: none;
  }
  
  .filters {
    font-size: 14px;
    line-height: 18px;
    margin-right: 10px;
    padding: 10px 20px !important;
    &:hover {
      border: 1px solid #222222 !important;
    }
    &:active,
    &:checked {
      border: 2px solid #222222 !important;
    }
  }
  .dropdown-menu {
    border-radius: 16px;
    p {
      color: #717171;
      font-size: 14px;
      padding: 10px 30px;
    }
    h5 {
      padding: 15px 0 0 30px;
    }
    .checkbtn {
      font-size: 30px;
      margin: 20px 20px -10px 5px;
      line-height: 10;
      background-color: #ccc;
      border-color: #ccc;
      box-shadow: 3px 3px 5px #fff;
      &:checked {
        background-color: #717171;
        border-color: #717171;
        box-shadow: 3px 3px 5px #cccccc;
      }
    }
    .type_place {
      padding: 20px 15px 10px 30px;
      h6 {
        margin-top: 10px;
        padding-left: 30px;
      }
    }
  }
  .more {
    .btn_ {
      width: 40px;
      height: 40px;
      background: transparent;
      border: 1px solid #717171;
      font-size: 25px;
      font-weight: bolder;
      color: #717171;
      margin-right: 20px;
      margin-bottom: 15px;
    }
    .btnAdd {
      width: 40px;
      height: 40px;
      background: transparent;
      border: 1px solid #717171;
      font-size: 20px;
      font-weight: bolder;
      color: #717171;
      margin-left: 20px;
      margin-bottom: 12px;
    }
    .moreOptions {
      h5 {
        font-size: 16px;
        margin-bottom: 2px;
        margin-top: 15px;
      }
      p {
        margin-bottom: 2px;
        font-size: 14px;
        color: #717171;
      }
      a {
        font-size: 14px;
      }
      .checkbtn {
        font-size: 30px;
        margin: 20px 20px -10px 5px;
        line-height: 10;
        background-color: #ccc;
        border-color: #ccc;
        box-shadow: 3px 3px 5px #fff;
        top: 410px;
        right: 100px;
        &:checked {
          background-color: #717171;
          border-color: #717171;
          box-shadow: 3px 3px 5px #cccccc;
        }
      }
    }
  }
}
</style>