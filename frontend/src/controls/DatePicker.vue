<template>
  <div class="form-control w-full">
    <label class="label justify-start">
      <span class="label-text text-neutral-content">{{ name }}</span>
      <span class="label-text text-error ml-2" v-if="vfield && vfield.$error">
          ( {{ vfield.$errors[0].$message }} )
      </span>
    </label>
    <DatePicker class="input input-bordered w-full "
           :value="modelValue"
           @change="$emit('update:modelValue', $event)"
           @close="vfield ? vfield.$touch: ''"
           :disabled="disabled"
           :editable="false"
    />
  </div>
</template>

<script>
import DatePicker from 'vue-datepicker-next';
import 'vue-datepicker-next/index.css';
import 'vue-datepicker-next/locale/ru';

export default {
  name: "VDatePicker",
  props: {
    name: {},
    vfield: {},
    modelValue: {},
    disabled: { default: false }
  },
  data() {
    return {
      ass: '',
    }
  },
  emits: ['update:modelValue'],
  components: {
    DatePicker
  }
}
</script>