\ lib/init-data-stack.fs.fs

\ This file is part of Sin Forth.

\ This file adds `init-data-stack` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012072123.
\ See change log at the end of the file.

\ ==============================================================

require s-p-0.fs \ `sp0`

get-order get-current

target-definitions

: init-data-stack ( -- )
  sp0 ix ldp#, ;

  \ doc{
  \
  \ init-data-stack ( -- )
  \
  \ Init the data stack pointer, which is the ``IX`` Z80 register, by
  \ storing the address returned by `sp0` into it.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <data_stack.fs>.
