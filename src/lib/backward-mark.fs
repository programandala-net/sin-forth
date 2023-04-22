\ lib/backward-mark.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1821+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

get-order get-current

compiler-definitions

: <mark ( -- dest )
  memory> @ ;

  \ doc{
  \
  \ <mark  Compiler: ( -- dest ) "backward-mark"
  \
  \ _dest_ is the current target memory pointer, which is hold by
  \ `memory>` to be used as the destination of a backward branch.
  \ _dest_ is typically only used by `<resolve` to compile a branch
  \ address.
  \
  \ See also: `>mark`, `begin`.
  \
  \ }doc

set-current set-order
