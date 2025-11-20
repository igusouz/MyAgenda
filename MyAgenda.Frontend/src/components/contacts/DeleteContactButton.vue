<script setup>
import { defineProps, defineEmits } from "vue";
import { api } from "../../api/http"

const props = defineProps({
  contactId: Number,
});

const emit = defineEmits(["deleted"]);

const handleDelete = async () => {
  if (confirm("Tem certeza que deseja deletar?")) {
    await api.delete(`/contacts/${props.contactId}`);
    emit("deleted");
  }
};
</script>

<template>
  <button @click="handleDelete">Deletar</button>
</template>