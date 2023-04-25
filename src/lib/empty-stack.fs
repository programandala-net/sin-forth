\ lib/empty-stack.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require s-p-0.fs \ `sp0`

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
