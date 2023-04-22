\ lib/empty-stack.fs

\ This file is part of Sin Forth.

\ This file adds `empty-stack` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require s-p-0.fs \ `sp0`

get-order get-current

target-definitions

: empty-stack ( -- )
  sp0 ix ldp#, ;

  \ doc{
  \
  \ empty-stack ( -- )
  \
  \ Empty the data stack by restoring its pointer, which is the ``IX``
  \ Z80 register, to its initial position, which is the address
  \ returned by `sp0`.
  \
  \ }doc

set-current set-order
