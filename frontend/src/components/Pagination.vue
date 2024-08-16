<template>
  <div class="demo-pagination-block-right">
    <el-pagination
        :current-page="index"
        :page-size="mySize"
        :page-sizes="[5, 10, 20,50,100]"
        :total="count"
        layout="total, sizes, prev, pager, next, jumper"
        @size-change="handleSizeChange"
        @current-change="handleCurrentChange"
    />
  </div>

</template>
<script lang="ts" setup>
import {toRefs} from 'vue'

const props = defineProps({
  index: {type:Number},
  mySize:{type:Number},
  count:{type:Number}
})

const emit = defineEmits<{
  (e: 'pageChange', index: number, size: number): void
}>()

let {index, mySize, count} = toRefs(props)

function handleCurrentChange(goToPage) {
  if (goToPage == index) return
  index = goToPage
  emit("pageChange", index, mySize)
}

function handleSizeChange(newPageSize) {
  if (newPageSize === mySize) return
  mySize = newPageSize
  emit("pageChange", index, mySize);
}
</script>

<style scoped>
.demo-pagination-block-right {
  text-align: right;
}
</style>
