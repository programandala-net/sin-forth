\ lib/empty-stack.fs

\ This file is part of Sin Forth.

\ This file adds `empty-stack` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012080116.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <data_stack.fs>.
\
\ 2020-12-08: Rename `init-data-stack` to `empty-stack`.
