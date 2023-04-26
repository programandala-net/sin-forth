\ test_move.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230426T1748+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

40000 set-origin

require sin_forth/lib/allot.fs
require sin_forth/lib/constant.fs
require sin_forth/lib/create.fs
require sin_forth/lib/for.fs
require sin_forth/lib/literal.fs
require sin_forth/lib/move-hl-de-bc.fs
require sin_forth/lib/pop-de.fs
require sin_forth/lib/pop-hl.fs
require sin_forth/lib/r-fetch.fs
require sin_forth/lib/step.fs

22528 h-constant attr   \ display attributes address
  768 h-constant /attr  \ display attributes size in bytes

t-here h-constant attr-copy
/attr t-allot

: save-attr ( -- )
  attr h ldp#,      \ ld hl, attr
  attr-copy d ldp#, \ ld de, attr_copy
  /attr b ldp#,     \ ld bc, attr_len
  move-hl-de-bc ;   \ jp move_hl_de_bc
  \ Move `/attr` bytes from `attr`, the display attributes address, to
  \ the `attr-copy` buffer.

: restore-attr ( -- )
  attr-copy h ldp#,  \ ld hl, attr_copy
  \ Move `/attr` bytes from the `attr-copy` buffer to `attr`, the
  \ display attributes address.

: hl-to-attr ( -- )
  attr d ldp#,    \ ld de, attr
  /attr b ldp#,   \ ld bc, attr_len
  move-hl-de-bc ; \ jp move_hl_de_bc
  \ Move `/attr` bytes from the address pointed by the `hl` register
  \ to `attr`, the display attributes address.

: wait ( -- )
  255 literal for step ;
  \ Execute a noop loop 256 times (255..0).

: rubbish ( u -- )
  for r@ pop-hl hl-to-attr wait step ;
  \ Copy _u+1_ times `/attr` bytes from the address pointed by the
  \ loop index (_u..0_) to `attr`, the display attributes address.

boot-here
exx, h push,

save-attr
255 literal rubbish
restore-attr

h pop, exx,
ret,

8 data-stack
