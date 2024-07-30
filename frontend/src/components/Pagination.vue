<template>     
  <nav aria-label="Page navigation">
    <ul class="pagination justify-content-end">
      <li class="page-item">
        <div class="input-group mb-3">
          <label class="input-group-text" for="inputGroupSelect01">Page Size</label>
          <select v-model="PageSize" class="form-select"  @change="changeSize(PageSize)">
            <option :value="1">1</option>
            <option :value="2">2</option>
            <option :value="3">3</option>
            <option :value="10" selected>10</option>
          </select>
        </div>
      
      </li>
      <li class="page-item" v-if="PageIndex > 1" @click.prevent="changePage(PageIndex-1)"><a class="page-link" href="#">Previous</a></li>
      <li class="page-item" :class="{ active: PageIndex == n}"  v-for="n in totalPages" :key="n" @click.prevent="changePage(n)">
        <span v-if="PageIndex == n" class="page-link">{{ n }}</span>
        <a v-else class="page-link" href>{{ n }}</a>
      </li>
      <li class="page-item" v-if="totalPages > PageIndex" @click.prevent="changePage(PageIndex+1)"><a class="page-link" href="#">Next</a></li>
    </ul>
  </nav>
</template>

<script>
export default {
  name: "DemoPagination",
  emits: ['changePageConfig'],
  data() {
    return{
      PaigeSize : 10,
      PageIndex :1
    }
  },
  props: {
    totalPages: {
      type: Number,
      required: true,
      default:1
    },
    pageIndex: {
      type: Number,
      required: true
    },
    pageSize: {
      type: Number,
      required: true
    }
  },
  methods: {
    changePage(goToPage) {
      // if (goToPage === this.pageIndex) return;
      console.log(goToPage);
      this.PageIndex = goToPage;
      this.$emit("changePageConfig", this.PageIndex ,this.PageSize);
    },
    changeSize(newPageSize) {
      // if (newPageSize === this.pageSize) return;
      console.log(newPageSize);
      this.$emit("changePageConfig", this.PageIndex ,this.PageSize);
    }
   
  }
};
</script>
