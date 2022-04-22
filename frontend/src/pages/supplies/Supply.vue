<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Редактирование поставки</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Товар на складе</span>
      </label>
      <Multiselect
          v-model="supply.productInWarehouse.productInWarehouseId"
          :searchable="true"
          valueProp="productInWarehouseId"
          :options="productsInWarehouse"
          :classes="multiselectClasses"
          disabled="true"
      >
        <template v-slot:singlelabel="{ value }">
          <div class="multiselect-single-label">
            <div>{{ `${value.product.name} - ${value.warehouse.name} (id: ${value.productInWarehouseId})` }}</div>
          </div>
        </template>

        <template v-slot:option="{ option }">
          {{ `${option.product.name} - ${option.warehouse.name}` }}
        </template>

      </Multiselect>
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-primary-content">Название поставщика</span>
      </label>
      <input type="text" readonly class="input input-bordered w-full text-neutral" v-model="supply.supplierName">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-primary-content">Количество товара</span>
      </label>
      <input type="text" readonly class="input input-bordered w-full text-neutral" v-model="supply.amount">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-primary-content">Дата поставки</span>
      </label>
      <input type="text" readonly class="input input-bordered w-full text-neutral" v-model="supply.date">
    </div>

    <button class="btn btn-primary mt-4" @click="this.$router.push(`/supply/${supply.supplyId}/edit`)">Редактировать</button>

  </div>
</template>

<script>
import axios from "@/axios";
import Multiselect from "@vueform/multiselect";
import multiselectClasses from "@/assets/multiselect-classes";

export default {
  name: "SupplyPage",
  data() {
    return {
      supply: {
        supplyId: this.$route.params.id,
        productInWarehouse: {}
      },
      productsInWarehouse: [],
      multiselectClasses
    }
  },
  methods: {
    save() {
      axios.put(`/Supply/${this.supply.supplyId}`, {
        productInWarehouseId: this.supply.productInWarehouse.productInWarehouseId,
        supplierName: this.supply.supplierName,
        amount: this.supply.amount,
        date: this.supply.date
      }).then(() => {
        this.$router.push(`/supply/${this.supply.supplyId}`)
      })
    }
  },
  created() {
    axios.get('/ProductInWarehouse').then((response) => this.productsInWarehouse = response.data)
    axios.get(`/Supply/${this.supply.supplyId}`).then((response) => this.supply = response.data)
  },
  components: {
    Multiselect
  }
}
</script>