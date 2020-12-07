\ lib/s-p-0.fs.fs

\ This file is part of Sin Forth.

\ This file adds `s-p-0` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012072129.
\ See change log at the end of the file.

\ ==============================================================

get-order get-current

target-definitions

data-stack-bottom constant sp0

  \ doc{
  \
  \ sp0 ( -- a )
  \
  \ Return address _a_, which is the bottom (high memory) address of
  \ the data stack.
  \
  \ See also: `init-data-stack`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-07: Extract the code from <data_stack.fs>.
