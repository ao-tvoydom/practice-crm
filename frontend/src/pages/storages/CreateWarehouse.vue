<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Добавить склад</div>

    <TextField name="Название" :vfield="v$.warehouse.name" v-model="warehouse.name"></TextField>
    <TextField name="Адрес" :vfield="v$.warehouse.address" v-model="warehouse.address"></TextField>

    <button class="btn btn-primary mt-4" @click="save">Сохранить</button>
  </div>
</template>

<script>
import axios from "@/axios";
import useVuelidate from "@vuelidate/core";
import validators from "@/validators";
import TextField from "@/controls/TextField";

export default {
  name: "CreateStoragePage",
  components: {TextField},
  setup () {
    return { v$: useVuelidate() }
  },
  data() {
    return {
      warehouse: {
        name: '',
        address: '',
        warehouseId: this.$route.params.id,
      }
    }
  },
  validations () {
    return {
      warehouse: {
        name: {
          checkLength: validators.checkLength(3, 50),
        },
        address: {
          checkLength: validators.checkLength(5, 120),
        }
      }
    }
  },
  methods: {
    async save() {
      const isFormCorrect = await this.v$.$validate();
      if(!isFormCorrect) return;

      axios.post(`/Warehouse`, this.warehouse).then((response) => {
        this.$router.push(`/warehouse/${response.data.warehouseId}`)
      })
    }
  }
}
</script>