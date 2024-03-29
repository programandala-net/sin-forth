\ lib/emit.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0908+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require pop-hl.fs \ `pop-hl`

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
