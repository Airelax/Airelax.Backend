<template>
  <div class="row top content">
    <div class="col-md-6 col-12 position-relative houses">
      <div class="back d-flex justify-content-between" v-if="$store.state.fullWidth < 768">
        <a href="/" class="ms-4"><img src="@/assets/image/Room/icon/back.svg"/></a>
        <div class="date">
          <span v-if="$store.getters.TotalCustomer != 0">·{{ $store.getters.TotalCustomer }}位房客</span>
          <span class="between">|</span>
          <a
              class="me-4"
              href="#"
              data-bs-toggle="offcanvas"
              data-bs-target="#offcanvasBottom"
              aria-controls="offcanvasBottom"
          ><img src="@/assets/image/Room/icon/setting.svg"
          /></a>
        </div>
      </div>
      <div class="px-4 pt-md-3">
        <div class="text-start m-md-4 pt-3">
          <span>{{ totalRooms }}間住宿</span>
          <span v-if="Object.keys($store.state.date).length != 0"> · {{
              $store.state.date.start
            }} - {{ $store.state.date.end }}</span>
          <span v-if="$store.getters.TotalCustomer != 0"> ·{{ $store.getters.TotalCustomer }}位房客</span>
          <h4>顯示「{{ $store.state.destination }}」的搜尋結果</h4>
          <div v-if="$store.state.fullWidth > 768">
            <div class="d-inline-block mb-3">
              <button
                  id="freeCancelDropdown"
                  type="button"
                  class="
                  filters
                  border border-1
                  bg-white
                  p-2
                  text-dark
                  btn-white
                  rounded-pill
                  dropdown-toggle
                "
                  :class="{'border-3 border-dark':$store.state.filters.freeCancel}"
                  data-bs-toggle="dropdown"
                  data-bs-auto-close="true"
              >
                免費退訂
              </button>
              <div
                  class="dropdown-menu mt-3"
                  aria-labelledby="freeCancelDropdown"
              >
                <p class="d-inline-block">僅顯示提供免費退訂的住宿</p>
                <div class="d-inline-block form-check form-switch">
                  <input
                      class="form-check-input checkbtn"
                      type="checkbox"
                      id="flexSwitchCheckDefault"
                      v-model="$store.state.filters.freeCancel"
                  />
                </div>
                <div class="modal-footer flex-nowrap justify-content-between">
                  <button
                      type="button"
                      class="btn btn-link text-dark fw-bold"
                      @click.prevent="$store.state.filters.freeCancel = false"
                  >
                    清除
                  </button>
                  <button
                      type="button"
                      class="btn bg-dark text-white dropdown-item w-25 text-center"
                      @click="getNewSearch"
                  >
                    儲存
                  </button>
                </div>
              </div>
            </div>
            <div class="d-inline-block">
              <button
                  id="roomCategoryDropdown"
                  type="button"
                  class="
                  filters
                  border border-1
                  bg-white
                  p-2
                  text-dark
                  btn-white
                  rounded-pill
                  dropdown-toggle
                "
                  :class="{'border-3 border-dark':$store.state.filters.roomCategories}"
                  data-bs-toggle="dropdown"
                  data-bs-auto-close="true"
              >
                房源類型
              </button>
              <div class="dropdown-menu mt-3" aria-labelledby="roomCategoryDropdown">
                <div
                    v-for="(item, index) in TypeOfPlace"
                    :key="index"
                    class="type_place"
                >
                  <input
                      type="checkbox"
                      id="item.id"
                      style="width: 20px; height: 20px"
                      class="roomCategoryInput"
                      :value="index+1"
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
                      @click="categoryReset"
                  >
                    清除
                  </button>
                  <button type="button" class="btn btn-dark" @click="getNewSearch">儲存</button>
                </div>
              </div>
            </div>
            <div class="d-inline-block">
              <button
                  v-if="$store.state.filters.lowPrice == '' && $store.state.filters.highPrice == ''"
                  id="priceDropdown" type="button"
                  class="filters border border-1 bg-white p-2 text-dark btn-white rounded-pill"
                  :class="{'border-3 border-dark':$store.state.filters.lowPrice || $store.state.filters.highPrice}"
                  data-bs-toggle="dropdown"
                  data-bs-auto-close="true"
              >
                價錢
              </button>
              <button
                  v-else
                  id="priceDropdown" type="button"
                  class="filters border border-1 bg-white p-2 text-dark btn-white rounded-pill"
                  :class="{'border-3 border-dark':$store.state.filters.lowPrice || $store.state.filters.highPrice}"
                  data-bs-toggle="dropdown"
                  data-bs-auto-close="true"
              >
                $ {{ $store.state.filters.lowPrice }} ~ {{ $store.state.filters.highPrice }}
              </button>
              <div class="dropdown-menu mt-3 px-3" aria-labelledby="priceDropdown">
                <div class="mt-3 d-flex w-100 justify-content-center px-3">
                  <input type="text" placeholder="最低價格" class="ms-1 py-2 border-1"
                         v-model="$store.state.filters.lowPrice">
                  <span class="mx-2 py-2">-</span>
                  <input type="text" placeholder="最高價格" class="ms-1 py-2 border-1"
                         v-model="$store.state.filters.highPrice">
                </div>
                <div class="modal-footer">
                  <button
                      type="button"
                      class="btn btn btn-link text-dark fw-bold"
                      @click="priceReset"
                  >
                    清除
                  </button>
                  <button type="button" class="btn bg-dark text-white dropdown-item w-25 text-center"
                          @click="getNewSearch">儲存
                  </button>
                </div>
              </div>
            </div>
            <div class="d-inline-block">
              <button
                  id="realtimeDropdown"
                  type="button"
                  class="
                  filters
                  border border-1
                  bg-white
                  p-2
                  text-dark
                  btn-white
                  rounded-pill
                  dropdown-toggle
                "
                  :class="{'border-3 border-dark':$store.state.filters.realtime}"
                  data-bs-toggle="dropdown"
                  data-bs-auto-close="true"
              >
                即時預訂
              </button>
              <div class="dropdown-menu" aria-labelledby="realtimeDropdown">
                <h5>即時預訂</h5>
                <p class="d-inline-block">無需等待房東批准即可預訂的房源</p>
                <div class="d-inline-block form-check form-switch">
                  <input
                      class="form-check-input checkbtn"
                      type="checkbox"
                      id="flexSwitchCheckDefault"
                      v-model="$store.state.filters.realtime"
                  />
                </div>
                <div class="modal-footer">
                  <button
                      type="button"
                      class="btn btn btn-link text-dark fw-bold"
                      @click.prevent="$store.state.filters.realtime = false"
                  >
                    清除
                  </button>
                  <button type="button" class="btn btn-dark" @click="getNewSearch">儲存</button>
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
              <div
                  class="more border rounded position-absolute text-start more"
              >
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
                        <div class="row px-0 pb-3 m-4 mt-2">
                          <h4 class="fw-bolder mb-4">設備與服務</h4>
                          <div class="row">
                            <div
                                class="col-6 mb-3"
                                v-for="item in optionlist[0]"
                                :key="item.id"
                            >
                              <input
                                  type="checkbox"
                                  :id="item.id"
                                  :value="item.value"
                                  class="facilityInput"
                              />
                              <label :for="item.id" class="ms-3"
                              >{{ item.title }}
                              </label>
                            </div>
                            <div class="collapse" id="collapseService">
                              <div class="empty row">
                                <div
                                    class="col-6 mb-3"
                                    v-for="item in optionlist[1]"
                                    :key="item.id"
                                >
                                  <input
                                      type="checkbox"
                                      :id="item.id"
                                      :value="item.value"
                                      class="facilityInput"
                                  />
                                  <label :for="item.id" class="ms-3"
                                  >{{ item.title }}
                                  </label>
                                </div>
                              </div>
                            </div>
                            <a
                                class="mt-3 text-dark fs-6 open-collapse"
                                data-bs-toggle="collapse"
                                href="#collapseService"
                                role="button"
                                aria-expanded="false"
                                aria-controls="collapseService"
                            >
                              點擊展開
                            </a>
                          </div>
                        </div>
                        <hr/>
                        <div class="row px-0 pb-3 m-4">
                          <h4 class="fw-bolder">設備</h4>
                          <div class="row">
                            <div
                                class="col-6 mb-3"
                                v-for="item in AmenitiesList"
                                :key="item.id"
                            >
                              <input
                                  type="checkbox"
                                  :id="item.id"
                                  :value="item.value"
                                  class="facilityInput"
                              />
                              <label :for="item.id" class="ms-3"
                              >{{ item.title }}
                              </label>
                            </div>
                          </div>
                        </div>
                        <hr/>
                        <div class="row px-0 pb-3 m-4">
                          <h4 class="fw-bolder">住宿類型</h4>
                          <div class="row">
                            <div
                                class="col-6 mb-3"
                                v-for="item in PropertyTypeList[0]"
                                :key="item.id"
                            >
                              <input
                                  type="checkbox"
                                  :id="item.id"
                                  :value="item.value"
                                  class="houseTypeInput"
                              />
                              <label :for="item.id" class="ms-3"
                              >{{ item.title }}
                              </label>
                            </div>
                            <div class="collapse" id="collapseHouseType">
                              <div class="empty row">
                                <div
                                    class="col-6 mb-3"
                                    v-for="item in PropertyTypeList[1]"
                                    :key="item.id"
                                >
                                  <input
                                      type="checkbox"
                                      :id="item.id"
                                      :value="item.value"
                                      class="featureInput"
                                  />
                                  <label :for="item.id" class="ms-3"
                                  >{{ item.title }}
                                  </label>
                                </div>
                              </div>
                            </div>
                            <a
                                class="mt-3 text-dark fs-6 open-collapse"
                                data-bs-toggle="collapse"
                                href="#collapseHouseType"
                                role="button"
                                aria-expanded="false"
                                aria-controls="collapseHouseType"
                            >
                              點擊展開
                            </a>
                          </div>
                        </div>
                        <hr/>
                        <div class="row px-0 pb-3 m-4">
                          <h4 class="fw-bolder">住宿特色</h4>
                          <div class="row">
                            <div
                                class="col-6 mb-3"
                                v-for="item in UniqueStaysList[0]"
                                :key="item.id"
                            >
                              <input
                                  type="checkbox"
                                  :id="item.id"
                                  :value="item.value"
                                  class="featureInput"
                              />
                              <label :for="item.id" class="ms-3"
                              >{{ item.title }}
                              </label>
                            </div>
                            <div class="collapse" id="collapseFeature">
                              <div class="empty row">
                                <div
                                    class="col-6 mb-3"
                                    v-for="item in UniqueStaysList[1]"
                                    :key="item.id"
                                >
                                  <input type="checkbox" :id="item.id" :value="item.value" class="featureInput"/>
                                  <label :for="item.id" class="ms-3"
                                  >{{ item.title }}
                                  </label>
                                </div>
                              </div>
                            </div>
                            <a
                                class="mt-3 text-dark fs-6 open-collapse"
                                data-bs-toggle="collapse"
                                href="#collapseFeature"
                                role="button"
                                aria-expanded="false"
                                aria-controls="collapseFeature"
                            >
                              點擊展開
                            </a>
                          </div>
                        </div>
                        <hr/>
                        <div class="row px-0 pb-3 m-4">
                          <h4 class="fw-bolder">房屋守則</h4>
                          <div class="row">
                            <div class="col-6 mb-3">
                              <input
                                  type="checkbox"
                                  :id="AllowPet"
                                  v-model="$store.state.filters.allowPet"
                              />
                              <label :for="AllowPet" class="ms-3">可攜帶寵物</label>
                            </div>
                            <div class="col-6">
                              <input
                                  type="checkbox"
                                  :id="AllowSmoke"
                                  v-model="$store.state.filters.allowSmoke"
                              />
                              <label :for="AllowSmoke" class="ms-3">可吸菸 </label>
                            </div>
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
                            @click="getNewSearch"
                        >
                          儲存
                        </button>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="onlybtn" v-if="$store.state.fullWidth < 768">
            <button
                class="
                filters
                border border-2
                bg-white
                py-2
                px-3
                mb-3
                text-dark
                btn-white
                rounded-pill
              "
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
                <h4 class="offcanvas-title ps-3" id="offcanvasBottomLabel">
                  篩選條件
                </h4>
                <button
                    type="button"
                    class="btn btn btn-link text-dark"
                    @click="resetSmall"
                >
                  清除
                </button>
              </div>
              <div class="offcanvas-body small">
                <div class="d-inline-block w-100">
                  <h4 class="fw-bold">房源類型</h4>
                  <div class="mt-3">
                    <div
                        v-for="(item, index) in TypeOfPlace"
                        :key="index"
                        class="type_place"
                    >
                      <div class="row mt-3">
                        <div class="col-10">
                          <label for="item.id">
                            <h6 class="mb-1">{{ item.title }}</h6>
                            <p>{{ item.text }}</p>
                          </label>
                        </div>
                        <div class="col-2 text-end">
                          <input
                              type="checkbox"
                              id="item.id"
                              style="width: 20px; height: 20px"
                              class="roomCategoryInput"
                              :value="index+1"
                          />
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <hr/>
                <div class="d-inline-block w-100">
                  <h4 class="fw-bold">即時預訂</h4>
                  <div class="d-flex justify-content-between align-items-center">
                    <p class="mb-0">無需等待房東批准即可預訂的房源</p>
                    <div class="form-check form-switch">
                      <input
                          class="form-check-input checkbtn mt-0"
                          type="checkbox"
                          id="flexSwitchCheckDefault"
                          v-model="$store.state.filters.realtime"
                      />
                    </div>
                  </div>
                </div>
                <hr/>
                <div class="d-inline-block w-100">
                  <h4 class="fw-bold">價格範圍</h4>
                  <div class="mt-3 d-flex w-100 justify-content-center align-items-center">
                    <input type="text" placeholder="最低價格" class="ms-1 mt-1 w-75 py-2"
                           v-model="$store.state.filters.lowPrice">
                    <span class="mx-2 mt-1">-</span>
                    <input type="text" placeholder="最高價格" class="ms-1 mt-1 w-75 py-2"
                           v-model="$store.state.filters.highPrice">
                  </div>
                </div>
                <hr/>
                <div class="d-inline-block w-100">
                  <h4 class="fw-bold">退訂彈性</h4>
                  <div class="mt-3 d-flex align-items-center justify-content-between">
                    <p class="mb-0">僅顯示提供免費退訂的住宿</p>
                    <div class=" form-check form-switch">
                      <input
                          class="form-check-input checkbtn ms-5 mt-0"
                          type="checkbox"
                          id="flexSwitchCheckDefault"
                          v-model="$store.state.filters.freeCancel"
                      />
                    </div>
                  </div>
                </div>
                <hr/>
                <div class="row px-0 pb-3">
                  <h4 class="fw-bolder mb-4">設備與服務</h4>
                  <div class="row">
                    <div
                        class="col-6 mb-3"
                        v-for="item in optionlist[0]"
                        :key="item.id"
                    >
                      <input
                          type="checkbox"
                          :id="item.id"
                          :value="item.value"
                          class="facilityInput"
                      />
                      <label :for="item.id" class="ms-3"
                      >{{ item.title }}
                      </label>
                    </div>
                    <div class="collapse" id="collapseService">
                      <div class="empty row">
                        <div
                            class="col-6 mb-3"
                            v-for="item in optionlist[1]"
                            :key="item.id"
                        >
                          <input
                              type="checkbox"
                              :id="item.id"
                              :value="item.value"
                              class="facilityInput"
                          />
                          <label :for="item.id" class="ms-3"
                          >{{ item.title }}
                          </label>
                        </div>
                      </div>
                    </div>
                    <a
                        class="mt-3 text-dark fs-6 open-collapse"
                        data-bs-toggle="collapse"
                        href="#collapseService"
                        role="button"
                        aria-expanded="false"
                        aria-controls="collapseService"
                    >
                      點擊展開
                    </a>
                  </div>
                </div>
                <hr/>
                <div class="row px-0 pb-3">
                  <h4 class="fw-bolder">設備</h4>
                  <div class="row">
                    <div
                        class="col-6 mb-3"
                        v-for="item in AmenitiesList"
                        :key="item.id"
                    >
                      <input
                          type="checkbox"
                          :id="item.id"
                          :value="item.value"
                          class="facilityInput"
                      />
                      <label :for="item.id" class="ms-3"
                      >{{ item.title }}
                      </label>
                    </div>
                  </div>
                </div>
                <hr/>
                <div class="row px-0 pb-3">
                  <h4 class="fw-bolder">住宿類型</h4>
                  <div class="row">
                    <div
                        class="col-6 mb-3"
                        v-for="item in PropertyTypeList[0]"
                        :key="item.id"
                    >
                      <input
                          type="checkbox"
                          :id="item.id"
                          :value="item.value"
                          class="houseTypeInput"
                      />
                      <label :for="item.id" class="ms-3"
                      >{{ item.title }}
                      </label>
                    </div>
                    <div class="collapse" id="collapseHouseType">
                      <div class="empty row">
                        <div
                            class="col-6 mb-3"
                            v-for="item in PropertyTypeList[1]"
                            :key="item.id"
                        >
                          <input
                              type="checkbox"
                              :id="item.id"
                              :value="item.value"
                              class="featureInput"
                          />
                          <label :for="item.id" class="ms-3"
                          >{{ item.title }}
                          </label>
                        </div>
                      </div>
                    </div>
                    <a
                        class="mt-3 text-dark fs-6 open-collapse"
                        data-bs-toggle="collapse"
                        href="#collapseHouseType"
                        role="button"
                        aria-expanded="false"
                        aria-controls="collapseHouseType"
                    >
                      點擊展開
                    </a>
                  </div>
                </div>
                <hr/>
                <div class="row px-0 pb-3">
                  <h4 class="fw-bolder">住宿特色</h4>
                  <div class="row">
                    <div
                        class="col-6 mb-3"
                        v-for="item in UniqueStaysList[0]"
                        :key="item.id"
                    >
                      <input
                          type="checkbox"
                          :id="item.id"
                          :value="item.value"
                          class="featureInput"
                      />
                      <label :for="item.id" class="ms-3"
                      >{{ item.title }}
                      </label>
                    </div>
                    <div class="collapse" id="collapseFeature">
                      <div class="empty row">
                        <div
                            class="col-6 mb-3"
                            v-for="item in UniqueStaysList[1]"
                            :key="item.id"
                        >
                          <input type="checkbox" :id="item.id" :value="item.value" class="featureInput"/>
                          <label :for="item.id" class="ms-3"
                          >{{ item.title }}
                          </label>
                        </div>
                      </div>
                    </div>
                    <a
                        class="mt-3 text-dark fs-6 open-collapse"
                        data-bs-toggle="collapse"
                        href="#collapseFeature"
                        role="button"
                        aria-expanded="false"
                        aria-controls="collapseFeature"
                    >
                      點擊展開
                    </a>
                  </div>
                </div>
                <hr/>
                <div class="row px-0 pb-3">
                  <h4 class="fw-bolder">房屋守則</h4>
                  <div class="row">
                    <div class="col-6">
                      <input
                          type="checkbox"
                          :id="AllowPet"
                          v-model="$store.state.filters.allowPet"
                      />
                      <label :for="AllowPet">可攜帶寵物</label>
                    </div>
                    <div class="col-6">
                      <input
                          type="checkbox"
                          :id="AllowSmoke"
                          v-model="$store.state.filters.allowSmoke"
                      />
                      <label :for="AllowSmoke">可吸菸 </label>
                    </div>
                  </div>
                </div>
                <hr/>
                <div class="sticky-top">
                  <button type="button" class="btn btn-dark w-100" @click="getNewSearch">
                    顯示結果
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="RoomType">
          <i v-if="!get" class="fas fa-spinner fa-spin" style="font-size:5rem;margin:5rem 0;"></i>
          <div class="col-12" v-if="get">
            <ResultRoom :rooms="rooms" :nightCount="$store.state.nightCount==0?1:$store.state.nightCount"></ResultRoom>
          </div>
        </div>
        <div class="page d-flex justify-content-center">
          <nav aria-label="Page navigation example d-block">
            <ul class="pagination rounded-circle">
              <li class="page-item">
                <a class="page-link text-dark border border-white" href="#"
                ><i class="fas fa-angle-left"></i
                ></a>
              </li>
              <li class="page-item" v-for="item in getPage" :key="item">
                <button class="page-link text-dark border border-white" href="#">{{
                    item
                  }}
                </button>
              </li>
              <li class="page-item">
                <a class="page-link text-dark border border-white" href="#"
                ><i class="fas fa-angle-right"></i
                ></a>
              </li>
            </ul>
          </nav>
        </div>
        <div>1 - {{ getPage }} 頁，共 {{ totalRooms }} 間住宿</div>
        <div class="my-4 text-secondary">
          需要支付額外費用。可能會加收稅費。
        </div>
      </div>
      <div class="Result">
        <div class="col-12" v-if="false && get">
          <BrowsingRecord
              :rooms="rooms"
              :nightCount="$store.state.nightCount==0?1:nightCount"
          ></BrowsingRecord>
        </div>
      </div>
    </div>
    <div class="col-6 map" v-if="$store.state.fullWidth > 768">
      <Map v-if="get" :location="location" :houses="rooms"></Map>
    </div>
  </div>
  <CreateWish></CreateWish>
  <Wish :wishLists="wishLists" @onWishListUpdated="onWishListUpdated"></Wish>
</template>

<script>
import axios from "axios";
import ResultRoom from "../components/Search/ResultRoom";
import BrowsingRecord from "../components/Search/BrowsingRecord";
import Map from "../components/Map/SearchMap.vue";
import settingJson from "../components/Settings/setting";
import Wish from "@/components/Search/Wish";
import CreateWish from "@/components/Search/CreateWish";

export default {
  created() {
    const query = this.$route.query;
    let searchApi = `/api/houses/search?location=${this.$route.query.location}`;
    if (query.checkin && query.checkout) searchApi += `&checkin=${query.checkin}&checkout=${query.checkout}`;
    searchApi += `&customerNumber=${query.customerNumber ? query.customerNumber : 1}`;
    if (this.$store.state.filters.freeCancel) searchApi += `&freecancel=${this.$store.state.filters.freeCancel}`;
    if (this.$store.state.filters.lowPrice !== "") searchApi += `&lowprice=${this.$store.state.filters.lowPrice}`;
    if (this.$store.state.filters.highPrice !== "") searchApi += `&highprice=${Number(this.$store.state.filters.highPrice)}`;
    if (this.$store.state.filters.realtime) searchApi += `&realtime=${this.$store.state.filters.realtime}`;
    if (this.$store.state.filters.roomCategories !== "") searchApi += `&roomcategories=${this.$store.state.filters.roomCategories}`;
    if (this.$store.state.filters.facilities !== "") searchApi += `&facilities=${this.$store.state.filters.facilities}`;
    if (this.$store.state.filters.houseTypes !== "") searchApi += `&categories=${this.$store.state.filters.houseTypes}`;
    if (this.$store.state.filters.features !== "") searchApi += `&houseTypes=${this.$store.state.filters.features}`;
    if (this.$store.state.filters.allowPet) searchApi += `&allowpet=${this.$store.state.filters.allowPet}`;
    if (this.$store.state.filters.allowSmoke) searchApi += `&allowsmoke=${this.$store.state.filters.allowSmoke}`;

    //todo

    const dataUrl = "/api/wishLists";
    axios
      .get(dataUrl)
      .then((res) => {
        console.log(res.data);
        this.wishLists = res.data;
        this.isWishListGet = true;
      })
      .catch((err) => {
        console.log(err);
      });

    axios.get(searchApi, {
      headers: {
        "Access-Control-Allow-Origin": "*",
      },
    })
        .then((res) => {
          console.log(res.data);
          const data = res.data;
          this.rooms = data.houses;
          this.totalRooms = data.total;
          this.getPicture();
          //Todo-Vuex-初始
          this.$store.state.room = {};
          this.location = data.locationInfo;
          this.get = true;
        });
  },
  mounted() {
    //roomCategory初始
    document.querySelectorAll('.roomCategoryInput').forEach((x, index) => {
      if (this.$store.state.filters.roomCategories.includes((index + 1).toString())) x.checked = true;
    })
    //facilities初始
    document.querySelectorAll('.facilityInput').forEach(x => {
      if (this.$store.state.filters.facilities.includes(x.value)) x.checked = true;
    })
    //houseTypes初始
    document.querySelectorAll('.houseTypeInput').forEach(x => {
      if (this.$store.state.filters.houseTypes.includes(x.value)) x.checked = true;
    })
    //features初始
    document.querySelectorAll('.featureInput').forEach(x => {
      if (this.$store.state.filters.features.includes(x.value)) x.checked = true;
    })

    // window.scrollTo(0, 0);
    const vm = this;
    window.addEventListener("scroll", function () {
      let top = document.documentElement.scrollTop;
      let back = this.document.querySelector(".back");
      if (back !== null) {
        if (top > 1 && vm.$store.state.fullWidth < 768)
          back.classList.add("fixed");
        else back.classList.remove("fixed");
      }
    });

    //展開/關閉
    document.querySelectorAll('.open-collapse').forEach(x => {
      x.addEventListener('click', (e) => {
        if (e.target.innerText == '點擊展開') e.target.innerText = '點擊關閉'
        else e.target.innerText = '點擊展開'
      })
    })
  },
  components: {
    ResultRoom,
    BrowsingRecord,
    Map,
    Wish,
    CreateWish,
  },
  data() {
    return {
      totalRooms: 0,
      setting: settingJson,
      rooms: Array,
      perPageRoomCount: 20,
      get: false,
      location: null,
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
          id: "SharedRoom",
          title: "合住房間",
          text: "入住共用房源，如公共休息室",
        },
      ],
      optionlist: [
        [
          {id: "Kitchen", title: "廚房", value: 813},
          {id: "Heating", title: "暖氣", value: 503},
          {id: "AirConditioner", title: "空調設備", value: 501},
          {id: "WashMachine", title: "洗衣機", value: 211},
        ],
        [
          {id: "Dryer", title: "乾衣機", value: 204},
          {id: "Wifi", title: "無線網路", value: 703},
          {id: "Breakfast", title: "早餐", value: 1201},
          {id: "HairDryer", title: "吹風機", value: 106},
          {id: "WorkSpace", title: "專門工作空間", value: 701},
          {id: "Television", title: "電視機", value: 310},
          {id: "HighChair", title: "兒童高腳椅", value: 411},
          {id: "LongTermStaysAllowed", title: "可長期住宿", value: 1203},
          {id: "SmokeAlarm", title: "煙霧警報器", value: 605},
          {id: "Essentials", title: "生活必需品", value: 201},
          {id: "BeachAccess", title: "直達海灘", value: 901},
          {id: "PrivateEntrance", title: "獨立入口", value: 904},
        ],
      ],
      AmenitiesList: [
        {id: "FreeBuildingParking", title: "建築物內免費停車", value: 1103},
        {id: "Gym", title: "健身房", value: 1105},
        {id: "Jacuzzi", title: "按摩浴池", value: 1106},
        {id: "Pool", title: "游泳池", value: 1109},
      ],
      PropertyTypeList: [
        [
          {id: "House", title: "獨棟房屋", value: 2},
          {id: "Apartment", title: "公寓", value: 1},
          {id: "BreakAndBreakfast", title: "家庭式旅館", value: 5},
          {id: "BoutiqueHotel", title: "精品旅店", value: 6},
        ],
        [
          {id: "Loft", title: "Loft空間", value: 103},
          {id: "Villa", title: "別墅", value: 203},
          {id: "Guesthouse", title: "客用住房", value: 301},
          {id: "GuestSuite", title: "客用套房", value: 302},
          {id: "Cabin", title: "小木屋", value: 202},
          {id: "Bungalow", title: "平房", value: 211},
          {id: "ServicedApartment", title: "服務式公寓", value: 607},
          {id: "Condo", title: "私有公寓", value: 102},
          {id: "Townhouse", title: "連棟房屋", value: 204},
          {id: "Hostel", title: "青年旅舍", value: 602},
          {id: "Hotel", title: "飯店", value: 601},
        ],
      ],
      UniqueStaysList: [
        [
          {id: "NatureLodge", title: "小屋", value: 502},
          {id: "Tent", title: "帳篷", value: 414},
          {id: "Cave", title: "洞穴", value: 408},
          {id: "Barn", title: "穀倉", value: 401},
        ],
        [
          {id: "Minsu", title: "臺灣民宿", value: 504},
          {id: "Ryokan", title: "日式旅館", value: 505},
          {id: "Camper", title: "露營車／休旅車", value: 404},
        ],
      ]
    };
  },
  inject: ["reload"],
  methods: {
    priceReset() {
      this.$store.state.filters.lowPrice = "";
      this.$store.state.filters.highPrice = "";
    },
    categoryReset() {
      document.querySelectorAll('.roomCategoryInput').forEach(x => {
        x.checked = false;
      })
    },
    reset() {
      document.querySelectorAll('.modal-dialog input').forEach(x => {
        x.checked = false;
      })
    },
    resetSmall() {
      document.querySelectorAll('.offcanvas input').forEach(x => {
        x.checked = false;
      })
      this.$store.state.filters.lowPrice = "";
      this.$store.state.filters.highPrice = "";
    },
    getNewSearch() {
      const isDateEmpty = Object.keys(this.$store.state.date).length === 0;

      //房源類型
      let roomCategories = [];
      document.querySelectorAll('.roomCategoryInput').forEach(x => {
        if (x.checked) roomCategories.push(Number(x.value))
      })
      this.$store.state.filters.roomCategories = roomCategories.join(',')

      //設備服務
      let facilities = [];
      document.querySelectorAll('.facilityInput').forEach(x => {
        if (x.checked) facilities.push(x.value)
      })
      this.$store.state.filters.facilities = facilities.join(',')

      //住宿類型
      let houseTypes = [];
      document.querySelectorAll('.houseTypeInput').forEach(x => {
        if (x.checked) houseTypes.push(x.value)
      })
      this.$store.state.filters.houseTypes = houseTypes.join(',')

      //住宿特色
      let features = [];
      document.querySelectorAll('.featureInput').forEach(x => {
        if (x.checked) features.push(x.value)
      })
      this.$store.state.filters.features = features.join(',')

      if (this.$route.meta.searchPage) {
        this.$router.replace({
          query: {
            location: this.$store.state.destination,
            customerNumber: this.$store.getters.TotalCustomer,
            checkin: isDateEmpty ? null : this.$store.state.date.start.replace(/[年]/, '-').replace(/[月]/, '-').replace('日', ''),
            checkout: isDateEmpty ? null : this.$store.state.date.end.replace(/[年]/, '-').replace(/[月]/, '-').replace('日', ''),
            freecancel: this.$store.state.filters.freeCancel,
            lowprice: this.$store.state.filters.lowPrice,
            highprice: this.$store.state.filters.highPrice,
            realtime: this.$store.state.filters.realtime,
            roomCategories: roomCategories.join(','),
            facilities: facilities.join(','),
            categories: houseTypes.join(','),
            houseTypes: features.join(','),
            allowPet: this.$store.state.filters.allowPet,
            allowSmoke: this.$store.state.filters.allowSmoke
          }
        })
        this.$nextTick(() => {
          this.reload();
        })
      }
    },
    onWishListUpdated(wishId, houseId) {
      //Todo 與愛心獨立事件有關的地方
      const focusWishHouses = this.wishLists.find(
        (x) => x.id === wishId
      ).houses;
      if (focusWishHouses.some((x) => x === houseId)) {
        const index = focusWishHouses.indexOf(houseId);
        focusWishHouses.splice(index, 1);
      } else focusWishHouses.push(houseId);
    },
    onCreateWishList(wishName, houseId) {
      //Todo 缺畫面同步,現有代碼不會動
      this.wishLists.push({ name: wishName, houses: [houseId] });
    },
    getRandomNumber(min, max) {
      return Math.floor(Math.random() * (max - min + 1)) + min;
    },
    getRandomList(min, max, num) {
      var list = [];
      while (list.length != num) {
        var randomNumber = Math.floor(Math.random() * (max - min + 1)) + min;
        if (
            !list.some((x) => {
              return x == randomNumber;
            })
        ) {
          list.push(randomNumber);
        }
      }
      return list;
    },
    //Todo-先給隨機Picture資料
    getPicture() {
      this.rooms.forEach((item) => {
        if (item.picture.length !== 0) return;
        this.getRandomList(
            0,
            this.setting.pictures.length - 1,
            this.getRandomNumber(5, this.setting.pictures.length - 1)
        ).forEach((x) => {
          item.picture.push(this.setting.pictures[x]);
        });
      });
    },
  },
  computed: {
    getPage: function () {
      return Math.ceil(
          Number(this.totalRooms) / Number(this.perPageRoomCount)
      );
    },
  },
};
</script>

<style scoped lang="scss">
.houses.position-relative,
.map {
  height: calc(100vh - 100px);
}

label {
  font-size: 1.1rem;
}

.back {
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

  &.fixed {
    position: fixed;
  }

  a {
    display: flex;
  }

  img {
    width: 1.2rem;
    cursor: pointer;
    margin: auto;
  }

  .date {
    display: flex;
  }

  .between {
    margin: 0 0.5rem;
  }
}

.btn-dark {
  border-radius: 8px;
}

.position-relative {
  padding: 0;
}

.record {
  background-color: #f7f7f7;
}

.text-start {
  p {
    font-size: 0.9rem;
  }

  h4 {
    font-size: 1.5em;
    font-weight: 700;
    margin: 1rem 0;
  }
}

.type_place {
  p {
    color: rgb(150, 150, 150);
  }
}

.onlybtn {
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

  .bed {
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
  label {
    font-size: 1.2rem;
  }
  .fake {
    height: 40rem;
    object-fit: cover;
  }
  .top {
    margin-right: 0 !important;
    margin-top: 90px;
  }
  .Result {
    .col-12 {
      background-color: #f7f7f7;
    }
  }
  .record {
    padding-left: 2rem;
  }
  .position-relative {
    padding: 0;
    overflow: auto;
    height: 40rem;

    &::-webkit-scrollbar {
      display: none;
    }
  }
  .text-start {
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