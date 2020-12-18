\ lib/backward-resolve.fs

\ This file is part of Sin Forth.

\ This file adds `<resolve` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012130050.
\ See change log at the end of the file.

\ ==============================================================

get-order get-current

compiler-definitions

: <resolve \ Compilation: ( dest -- )
  memory> @ 2 - t-! ;

  \ doc{
  \
  \ <resolve  Compilation: ( dest -- ) "backward-resolve"
  \
  \ Resolve a backward branch.  Set _set_ as the destination address
  \ of a Z80 ``jp`` instruction just compiled. _dest_ was usually left
  \ on the stack by `<mark`.
  \
  \ See also: `>resolve`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
\
\ 2020-12-12: Finish and document.
\
\ 2020-12-13: Fix.
