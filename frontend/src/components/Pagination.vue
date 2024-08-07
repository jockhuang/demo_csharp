<template>
   <div class="demo-pagination-block-right">
    <el-pagination
      :current-page="PageIndex"
      :page-size="PageSize"
      :page-sizes="[5, 10, 20,50,100]"
      layout="total, sizes, prev, pager, next, jumper"
      :total="totalCount"
      @size-change="handleSizeChange"
      @current-change="handleCurrentChange"
    />
  </div>
  
</template>

<script>
export default {
  name: "DemoPagination",
  emits: ['changePageConfig'],
  data() {
    return{
      PageSize :this.pageSize,
      PageIndex :this.pageIndex,
    }
  },
  props: {
    totalCount: {
      type: Number,
      required: true,
      default:0
    },
    pageIndex: {
      type: Number,
      required: true
    },
    pageSize: {
      type: Number,
      required: true
    },
  },
  mounted(){
    // console.log("pageIndex:"+this.PageIndex+",PageSize:"+this.PageSize);
  },
  methods: {
    handleCurrentChange(goToPage) {
      if (goToPage === this.pageIndex) return;
      this.PageIndex = goToPage;
      this.$emit("changePageConfig", this.PageIndex ,this.PageSize);
    },
    handleSizeChange(newPageSize) {
      if (newPageSize === this.pageSize) return;
      this.PageSize = newPageSize;
      this.$emit("changePageConfig", this.PageIndex ,this.PageSize);
    }
   
  }
};
</script>

<style scoped>
.demo-pagination-block-right{
  text-align:right;
}
</style>
