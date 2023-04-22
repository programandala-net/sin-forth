\ lib/emit.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require pop-hl.fs \ `pop-hl`

get-order get-current

target-definitions

: emit ( c -- )
  pop-hl
  l a ld,       \ ld a,l
: emit-a
  $10 rst,      \ rst $10
  $FF a ld#,    \ ld a,$FF
  #23692 sta, ; \ ld(sys_scr_ct),a ; no "scroll?" message

  \ doc{
  \
  \ emit ( c -- )
  \
  \ Display character _c_.
  \
  \ See also: `emit-a`, `cr`.
  \
  \ }doc

  \ doc{
  \
  \ emit-a ( -- )
  \
  \ Display the character contained in the ``A`` Z80 register.
  \
  \ See also: `emit`, `cr`.
  \
  \ }doc

set-current set-order
