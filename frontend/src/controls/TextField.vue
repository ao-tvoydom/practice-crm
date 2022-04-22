<template>
  <div class="form-control w-full">
    <label class="label justify-start">
      <span class="label-text text-neutral-content">{{ name }}</span>
      <span class="label-text text-error ml-2" v-if="vfield.$error">
          ( {{ vfield.$errors[0].$message }} )
        </span>
    </label>
    <input :type="type"
           class="input input-bordered w-full "
           :value="modelValue"
           @input="$emit('update:modelValue', $event.target.value)"
           @blur="vfield.$touch"
           :readonly="readonly"
    >
  </div>
</template>

<script>
export default {
  name: "TextField",
  props: {
    name: {},
    vfield: {},
    modelValue: {},
    type: { default: 'text'},
    readonly: { default: false }
  },
  emits: ['update:modelValue'],
}
</script>
