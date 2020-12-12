\ lib/branch.fs

\ This file is part of Sin Forth.

\ This file adds `branch` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012130037.
\ See change log at the end of the file.

\ ==============================================================

require pop-hl.fs

get-order get-current

compiler-definitions

synonym branch jp,

  \ doc{
  \
  \ branch  Compilation: ( dest -- ) Run-time:    ( -- )
  \
  \ Compilation: compile the Z80 ``jp`` instruction to jump
  \ unconditionally to _dest_.
  \
  \ Run-time: branch unconditionally to _dest_.
  \
  \ // XXX TODO // See also: `?branch`, `0branch`, `-branch`,
  \ `+branch`.
  \
  \ See also: `0branch`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
\
\ 2020-12-12: Finish and document.
\
\ 2020-12-13: Define as a synonym.
