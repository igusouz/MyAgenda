<script setup>
import { ref } from "vue";
import { deleteContact } from "../../api/contactsService";
import ConfirmDelete from "./ConfirmDelete.vue";

const props = defineProps({
  contactId: Number,
  contactName: String,
});

const emit = defineEmits(["deleted"]);

const showConfirm = ref(false);

const handleDelete = async () => {
  try {
    await deleteContact(props.contactId);
    emit("deleted");
    showConfirm.value = false;
  } catch (err) {
    console.error("Erro ao deletar contato:", err);
  }
};
</script>

<template>
  <div>
    <button
      @click="showConfirm = true"
      class="px-3 py-1 bg-red-600 text-white rounded hover:bg-red-700 text-sm transition"
    >
      Deletar
    </button>

    <ConfirmDelete
      :visible="showConfirm"
      :contactName="props.contactName"
      @cancel="showConfirm = false"
      @confirm="handleDelete"
    />
  </div>
</template>