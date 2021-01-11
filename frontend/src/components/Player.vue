<template>
  <div class="player">
    <Card
      class="hp"
      type="characters"
      :reverseSide="true"
      :rotate="true"
      :class="`hpCover${player.hp}`"
    />
    <Card class="character" :name="player.character" type="characters" />
    <Card class="role" :name="player.role" type="roles" :reverseSide="hideRole" />
  </div>
</template>

<script>
import Card from "./Card";

export default {
  name: "Player",
  components: {
    Card
  },
  props: {
    player: { required: true },
    isMe: { type: Boolean, default: false }
  },
  computed: {
    hideRole() {
      if (this.player.role == "sheriff") return false;

      if (this.player.hp == 0) return false;

      return !this.isMe; // is it me?
    }
  }
};
</script>

<style lang="sass">
@import ../constants

.player
  display: grid
  grid-auto-flow: column

  .hp
    display: grid
    justify-items: center
    z-index: 1
    &.hpCover0
      margin-right: $hpCover0
    &.hpCover1
      margin-right: $hpCover1
    &.hpCover2
      margin-right: $hpCover2
    &.hpCover3
      margin-right: $hpCover3
    &.hpCover4
      margin-right: $hpCover4
    &.hpCover5
      margin-right: $hpCover5
  .character
    z-index: 5
  .role
    z-index: 2
    margin-left: $roleCover

.me .player
  .hp
    &.hpCover0
      margin-right: $myHpCover0
    &.hpCover1
      margin-right: $myHpCover1
    &.hpCover2
      margin-right: $myHpCover2
    &.hpCover3
      margin-right: $myHpCover3
    &.hpCover4
      margin-right: $myHpCover4
    &.hpCover5
      margin-right: $myHpCover5
  .role
    margin-left: $myRoleCover
</style>
